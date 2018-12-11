<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="Invoice.aspx.vb" Inherits="ssiFinal.Invoice" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintPanel() {
            $('a').hide();
            var panel = document.getElementById("<%=Panel1.ClientID%>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><link rel="stylesheet" type="text/css" href="theme/assets/uniform/css/uniform.default.css" /><link href="theme/assets/font-awesome/css/font-awesome.css" rel="stylesheet" /><link href="theme/css/style.css" rel="stylesheet" /><link href="theme/css/style-default.css" rel="stylesheet" id="style_color" /><link href="theme/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" /><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            $('a').show();
            return false;
        }
    </script>
    <script type="text/javascript">
        //  This file is part of the jQuery formatCurrency Plugin.
        //
        //    The jQuery formatCurrency Plugin is free software: you can redistribute it
        //    and/or modify it under the terms of the GNU General Public License as published 
        //    by the Free Software Foundation, either version 3 of the License, or
        //    (at your option) any later version.

        //    The jQuery formatCurrency Plugin is distributed in the hope that it will
        //    be useful, but WITHOUT ANY WARRANTY; without even the implied warranty 
        //    of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
        //    GNU General Public License for more details.
        //
        //    You should have received a copy of the GNU General Public License along with 
        //    the jQuery formatCurrency Plugin.  If not, see <http://www.gnu.org/licenses/>.

        (function ($) {

            $.formatCurrency = {};

            $.formatCurrency.regions = [];

            // default Region is en
            $.formatCurrency.regions[''] = {
                symbol: 'Php',
                positiveFormat: '%s%n',
                negativeFormat: '(%s%n)',
                decimalSymbol: '.',
                digitGroupSymbol: ',',
                groupDigits: true
            };

            $.fn.formatCurrency = function (destination, settings) {

                if (arguments.length == 1 && typeof destination !== "string") {
                    settings = destination;
                    destination = false;
                }

                // initialize defaults
                var defaults = {
                    name: "formatCurrency",
                    colorize: false,
                    region: '',
                    global: true,
                    roundToDecimalPlace: 2, // roundToDecimalPlace: -1; for no rounding; 0 to round to the dollar; 1 for one digit cents; 2 for two digit cents; 3 for three digit cents; ...
                    eventOnDecimalsEntered: false
                };
                // initialize default region
                defaults = $.extend(defaults, $.formatCurrency.regions['']);
                // override defaults with settings passed in
                settings = $.extend(defaults, settings);

                // check for region setting
                if (settings.region.length > 0) {
                    settings = $.extend(settings, getRegionOrCulture(settings.region));
                }
                settings.regex = generateRegex(settings);

                return this.each(function () {
                    $this = $(this);

                    // get number
                    var num = '0';
                    num = $this[$this.is('input, select, textarea') ? 'val' : 'html']();

                    //identify '(123)' as a negative number
                    if (num.search('\\(') >= 0) {
                        num = '-' + num;
                    }

                    if (num === '' || (num === '-' && settings.roundToDecimalPlace === -1)) {
                        return;
                    }

                    // if the number is valid use it, otherwise clean it
                    if (isNaN(num)) {
                        // clean number
                        num = num.replace(settings.regex, '');

                        if (num === '' || (num === '-' && settings.roundToDecimalPlace === -1)) {
                            return;
                        }

                        if (settings.decimalSymbol != '.') {
                            num = num.replace(settings.decimalSymbol, '.');  // reset to US decimal for arithmetic
                        }
                        if (isNaN(num)) {
                            num = '0';
                        }
                    }

                    // evalutate number input
                    var numParts = String(num).split('.');
                    var isPositive = (num == Math.abs(num));
                    var hasDecimals = (numParts.length > 1);
                    var decimals = (hasDecimals ? numParts[1].toString() : '0');
                    var originalDecimals = decimals;

                    // format number
                    num = Math.abs(numParts[0]);
                    num = isNaN(num) ? 0 : num;
                    if (settings.roundToDecimalPlace >= 0) {
                        decimals = parseFloat('1.' + decimals); // prepend "0."; (IE does NOT round 0.50.toFixed(0) up, but (1+0.50).toFixed(0)-1
                        decimals = decimals.toFixed(settings.roundToDecimalPlace); // round
                        if (decimals.substring(0, 1) == '2') {
                            num = Number(num) + 1;
                        }
                        decimals = decimals.substring(2); // remove "0."
                    }
                    num = String(num);

                    if (settings.groupDigits) {
                        for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3) ; i++) {
                            num = num.substring(0, num.length - (4 * i + 3)) + settings.digitGroupSymbol + num.substring(num.length - (4 * i + 3));
                        }
                    }

                    if ((hasDecimals && settings.roundToDecimalPlace == -1) || settings.roundToDecimalPlace > 0) {
                        num += settings.decimalSymbol + decimals;
                    }

                    // format symbol/negative
                    var format = isPositive ? settings.positiveFormat : settings.negativeFormat;
                    var money = format.replace(/%s/g, settings.symbol);
                    money = money.replace(/%n/g, num);

                    // setup destination
                    var $destination = $([]);
                    if (!destination) {
                        $destination = $this;
                    } else {
                        $destination = $(destination);
                    }
                    // set destination
                    $destination[$destination.is('input, select, textarea') ? 'val' : 'html'](money);

                    if (
                        hasDecimals &&
                        settings.eventOnDecimalsEntered &&
                        originalDecimals.length > settings.roundToDecimalPlace
                    ) {
                        $destination.trigger('decimalsEntered', originalDecimals);
                    }

                    // colorize
                    if (settings.colorize) {
                        $destination.css('color', isPositive ? 'black' : 'red');
                    }
                });
            };

            // Remove all non numbers from text
            $.fn.toNumber = function (settings) {
                var defaults = $.extend({
                    name: "toNumber",
                    region: '',
                    global: true
                }, $.formatCurrency.regions['']);

                settings = jQuery.extend(defaults, settings);
                if (settings.region.length > 0) {
                    settings = $.extend(settings, getRegionOrCulture(settings.region));
                }
                settings.regex = generateRegex(settings);

                return this.each(function () {
                    var method = $(this).is('input, select, textarea') ? 'val' : 'html';
                    $(this)[method]($(this)[method]().replace('(', '(-').replace(settings.regex, ''));
                });
            };

            // returns the value from the first element as a number
            $.fn.asNumber = function (settings) {
                var defaults = $.extend({
                    name: "asNumber",
                    region: '',
                    parse: true,
                    parseType: 'Float',
                    global: true
                }, $.formatCurrency.regions['']);
                settings = jQuery.extend(defaults, settings);
                if (settings.region.length > 0) {
                    settings = $.extend(settings, getRegionOrCulture(settings.region));
                }
                settings.regex = generateRegex(settings);
                settings.parseType = validateParseType(settings.parseType);

                var method = $(this).is('input, select, textarea') ? 'val' : 'html';
                var num = $(this)[method]();
                num = num ? num : "";
                num = num.replace('(', '(-');
                num = num.replace(settings.regex, '');
                if (!settings.parse) {
                    return num;
                }

                if (num.length == 0) {
                    num = '0';
                }

                if (settings.decimalSymbol != '.') {
                    num = num.replace(settings.decimalSymbol, '.');  // reset to US decimal for arthmetic
                }

                return window['parse' + settings.parseType](num);
            };

            function getRegionOrCulture(region) {
                var regionInfo = $.formatCurrency.regions[region];
                if (regionInfo) {
                    return regionInfo;
                }
                else {
                    if (/(\w+)-(\w+)/g.test(region)) {
                        var culture = region.replace(/(\w+)-(\w+)/g, "$1");
                        return $.formatCurrency.regions[culture];
                    }
                }
                // fallback to extend(null) (i.e. nothing)
                return null;
            }

            function validateParseType(parseType) {
                switch (parseType.toLowerCase()) {
                    case 'int':
                        return 'Int';
                    case 'float':
                        return 'Float';
                    default:
                        throw 'invalid parseType';
                }
            }

            function generateRegex(settings) {
                if (settings.symbol === '') {
                    return new RegExp("[^\\d" + settings.decimalSymbol + "-]", "g");
                }
                else {
                    var symbol = settings.symbol.replace('$', '\\$').replace('.', '\\.');
                    return new RegExp(symbol + "|[^\\d" + settings.decimalSymbol + "-]", "g");
                }
            }

        })(jQuery);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MessagesPlaceHolder" runat="server">
    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
        <i class="icon-envelope-alt"></i>
        <span id="TotalMessages" runat="server" class="badge badge-warning"></span>
    </a>
    <ul id="messagesNotif" class="dropdown-menu extended inbox portlet-scroll-1" runat="server">
    </ul>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="AlertsPlaceHolder" runat="server">
    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
        <i class="icon-bell-alt"></i>
        <span id="TotalCount" runat="server" class="badge badge-warning"></span>
    </a>
    <ul class="dropdown-menu extended notification" id="Notifications" runat="server">
    </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        window.setInterval(function () {
            var grandTotal = 0;
            var monthlyStorage = $('#<%= GridViewMonthlyStorage.ClientID%> tr:last').find('td:last').html();
            var handlingIn = $('#<%= GridViewItemHandlingIn.ClientID%> tr:last').find('td:last').html();
            var handlingOut = $('#<%= GridViewHandlingOut.ClientID%> tr:last').find('td:last').html();
            var others = $('#<%= GridViewOthers.ClientID%> tr:last').find('td:last').html();



            monthlyStorage = monthlyStorage.replace(/[^\d.-]/g,"");
            handlingIn = handlingIn.replace(/[^\d.-]/g,"");
            handlingOut = handlingOut.replace(/[^\d.-]/g, "");
            others = others.replace(/[^\d.-]/g, "");

            if ($.isNumeric(monthlyStorage)) { } else { monthlyStorage = 0; }
            if ($.isNumeric(handlingIn)) { } else { handlingIn = 0; }
            if ($.isNumeric(handlingOut)) { } else { handlingOut = 0; }
            if ($.isNumeric(others)) { } else { others = 0; }

            var totalItemHandling = parseFloat(handlingIn) + parseFloat(handlingOut);
            var subTotal = parseFloat(monthlyStorage) + parseFloat(totalItemHandling) + parseFloat(others);
            var taxConsumption = 0;
            if ($('#<%= CheckBox1.ClientID%>').is(':checked')) {
                taxConsumption = subTotal * .12;
            } else {
                axConsumption = 0;
            }
            


            if (subTotal != 0) {
                grandTotal = subTotal + taxConsumption;
            }

            $('#<%= LabelConsumptionTax.ClientID%>').text(taxConsumption);
            $('#<%= LabelConsumptionTax.ClientID%>').formatCurrency('#<%= LabelConsumptionTax.ClientID%>');
            $('#<%= LabelSubTotalCharges.ClientID%>').text(subTotal);
            $('#<%= LabelSubTotalCharges.ClientID%>').formatCurrency('#<%= LabelSubTotalCharges.ClientID%>');

            if (parseFloat(monthlyStorage) != 0 && $.isNumeric(monthlyStorage)) {
                $('#<%= LabelTotalChargesStorage.ClientID%>').text(monthlyStorage);
                $('#<%= LabelTotalChargesStorage.ClientID%>').formatCurrency('#<%= LabelTotalChargesStorage.ClientID%>');
            }

            if (totalItemHandling != 0 && $.isNumeric(totalItemHandling)) {
                $('#<%= LabelTotalChargesItemHandling.ClientID%>').text(totalItemHandling);
                $('#<%= LabelTotalChargesItemHandling.ClientID%>').formatCurrency('#<%= LabelTotalChargesItemHandling.ClientID%>');
            }

            if (parseFloat(others) != 0 && $.isNumeric(others)) {
                $('#<%= LabelTotalChargesSpecialServices.ClientID%>').text(others);
                $('#<%= LabelTotalChargesSpecialServices.ClientID%>').formatCurrency('#<%= LabelTotalChargesSpecialServices.ClientID%>');
            }

            if (grandTotal != 0 && $.isNumeric(grandTotal)) {
                $('#<%= LabelTotalTransaction.ClientID%>').text(grandTotal);
                $('#<%= LabelTotalTransaction.ClientID%>').formatCurrency('#<%= LabelTotalTransaction.ClientID%>');
            }
        }, 100);
    </script>
    <script>
        $(function () {
            $(<%= dp1.ClientID%>).datepicker();
            $("#anim").change(function () {
                $("#datepicker").datepicker("option", "showAnim", $(this).val());
            });
        });
    </script>
    <div class="row-fluid non-print">
        <div class="span12">
            <div class="widget red">
                <div class="widget-title">
                    <h4><i class="icon-reorder"></i>Create Invoice</h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        &nbsp;<div class="controls">
                            <asp:DropDownList ID="DropDownListCompanyList" runat="server" DataSourceID="SqlDataSourceCompanyList" DataTextField="CompanyName" DataValueField="CompanyCode"></asp:DropDownList>
                            &nbsp;Invoice From Date:
                            <asp:TextBox ID="dp1" runat="server" CssClass="m-ctrl-medium"></asp:TextBox>
                            <asp:Button ID="ButtonGenerateInvoice" runat="server" Text="Generate Invoice" CssClass="btn btn-primary" />
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <label class="control-label">Invoice List</label>
                            <asp:GridView ID="GridViewInvoiceList" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceInsertInvoice" CssClass="table table-striped table-hover" AllowPaging="True">
                                <Columns>
                                    <asp:CommandField SelectText="View Invoice" ShowSelectButton="True" />
                                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                    <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                                    <asp:BoundField DataField="DateRange" HeaderText="DateRange" SortExpression="DateRange" />
                                </Columns>
                            </asp:GridView>
                            <div class="row-fluid">
        <div class="span4">
            <div class="widget red no-bottom-space">
                <div class="widget-title">
                    <h4><i class="icon-reorder"></i>Add an Item</h4>
                </div>
                <div class="widget-body">
                    <div class="controls">
                        <label class="control-label">Category:</label>
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="span12">
                            <asp:ListItem Value="ItemHandling_HandlingIn">Handling In</asp:ListItem>
                            <asp:ListItem Value="ItemHandling_HandlingOut">Handling Out</asp:ListItem>
                            <asp:ListItem Value="MonthlyStorageFee">Monthly Storage</asp:ListItem>
                            <asp:ListItem>Others</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <asp:FormView ID="FormView1" runat="server" DataKeyNames="Id" DefaultMode="Insert" Width="100%">
                        <InsertItemTemplate>
                            <label class="control-label">Item Name:</label>
                            <asp:TextBox ID="ItemTextBox" runat="server" Text='<%# Bind("Item") %>' CssClass="span12" />
                            <label class="control-label">Quantity:</label>
                            <asp:TextBox ID="QuantityTextBox" runat="server" Text='<%# Bind("Quantity") %>' CssClass="span12" onkeypress="CheckNumeric(event);" />
                            <label class="control-label">Rate:</label>
                            <asp:TextBox ID="RateTextBox" runat="server" Text='<%# Bind("Rate") %>' CssClass="span12" onkeypress="CheckNumeric(event);" />
                            <br />
                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Add Item" CssClass="btn btn-primary" />
                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="btn btn-primary" />
                        </InsertItemTemplate>
                    </asp:FormView>
                </div>
            </div>
        </div>
    </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:LinkButton ID="lnkPrint" runat="server" ToolTip="Click to Print Invoice" Text="Print Invoice" OnClientClick="return PrintPanel();" CssClass="btn-link"></asp:LinkButton>
    <asp:Panel ID="Panel1" runat="server">
        <div class="printables">
            <div class="row-fluid">
                <div class="span12">
                    <div class="text-center">
                        <h4>
                            <asp:Label ID="LabelTitle" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <h3>Monthly Storage</h3>
                            <asp:GridView ID="GridViewMonthlyStorage" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceStorageFee" ShowFooter="True" GridLines="Horizontal">
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="False" />
                                    <asp:BoundField DataField="InvoiceId" HeaderText="InvoiceId" SortExpression="InvoiceId" Visible="False" />
                                    <asp:BoundField DataField="ItemType" HeaderText="ItemType" SortExpression="ItemType" Visible="False" />
                                    <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                                    <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LabelQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="X"></asp:TemplateField>
                                    <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" />
                                    <asp:TemplateField HeaderText="Total" SortExpression="Total">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxTotal" runat="server" Text='<%# Bind("Total") %>' ReadOnly="true"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LabelTotal" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    No Items.
                                </EmptyDataTemplate>
                                <FooterStyle Font-Bold="True" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row-fluid">
                <div class="span12">
                    <div class="control-group">
                        <div class="controls">
                            <h3>Item Handling</h3>
                            <h4>Handling In</h4>
                            <asp:GridView ID="GridViewItemHandlingIn" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceHandlingIn" CssClass="table table-striped table-hover" GridLines="Horizontal" ShowFooter="True">
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="False" />
                                    <asp:BoundField DataField="InvoiceId" HeaderText="InvoiceId" SortExpression="InvoiceId" Visible="False" />
                                    <asp:BoundField DataField="ItemType" HeaderText="ItemType" SortExpression="ItemType" Visible="False" />
                                    <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                                    <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LabelQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="X"></asp:TemplateField>
                                    <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" />
                                    <asp:TemplateField HeaderText="Total" SortExpression="Total">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxTotal" runat="server" Text='<%# Bind("Total") %>' ReadOnly="true"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LabelTotal" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    No Items.
                                </EmptyDataTemplate>
                                <FooterStyle Font-Bold="True" />
                            </asp:GridView>
                        </div>
                        <div class="controls">
                            <h4>Handling Out</h4>
                            <asp:GridView ID="GridViewHandlingOut" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceHandlingOut" GridLines="Horizontal" ShowFooter="True" CssClass="table table-striped table-hover">
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="False" />
                                    <asp:BoundField DataField="InvoiceId" HeaderText="InvoiceId" SortExpression="InvoiceId" Visible="False" />
                                    <asp:BoundField DataField="ItemType" HeaderText="ItemType" SortExpression="ItemType" Visible="False" />
                                    <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                                    <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LabelQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="X"></asp:TemplateField>
                                    <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" />
                                    <asp:TemplateField HeaderText="Total" SortExpression="Total">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxTotal" runat="server" Text='<%# Bind("Total") %>' ReadOnly="true"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LabelTotal" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    No Items.
                                </EmptyDataTemplate>
                                <FooterStyle Font-Bold="True" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row-fluid">
                <div class="span12">
                    <div class="control-group">
                        <div class="controls">
                            <h3>Others</h3>
                            <asp:GridView ID="GridViewOthers" runat="server" DataKeyNames="Id" GridLines="Horizontal" ShowFooter="True" CssClass="table table-striped table-hover" DataSourceID="SqlDataSourceOthers" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="False" />
                                    <asp:BoundField DataField="InvoiceId" HeaderText="InvoiceId" SortExpression="InvoiceId" Visible="False" />
                                    <asp:BoundField DataField="ItemType" HeaderText="ItemType" SortExpression="ItemType" Visible="False" />
                                    <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                                    <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LabelQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="X"></asp:TemplateField>
                                    <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" />
                                    <asp:TemplateField HeaderText="Total" SortExpression="Total">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxTotal" runat="server" Text='<%# Bind("Total") %>' ReadOnly="true"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LabelTotal" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    No Items.
                                </EmptyDataTemplate>
                                <FooterStyle Font-Bold="True" />
                            </asp:GridView>
                            <div class="span4 invoice-block pull-right">
                                <ul class="unstyled amounts">
                                    <li><strong>Total Charges-Storage :</strong>
                                        <asp:Label ID="LabelTotalChargesStorage" runat="server" Text="Php0.00"></asp:Label></li>
                                    <li><strong>Total Charges-Item Handling :</strong>
                                        <asp:Label ID="LabelTotalChargesItemHandling" runat="server" Text="Php0.00"></asp:Label></li>
                                    <li><strong>Total Charges-Special Services :</strong>
                                        <asp:Label ID="LabelTotalChargesSpecialServices" runat="server" Text="Php0.00"></asp:Label></li>
                                    <li><strong>Sub Total Transactions :</strong>
                                        <asp:Label ID="LabelSubTotalCharges" runat="server" Text="Php0.00"></asp:Label></li>
                                    <li>
                                        <div class="checkbox"><asp:CheckBox ID="CheckBox1" runat="server" Text="VAT Inclusive" AutoPostBack="True" CssClass="checkbox" Width="200px"/></div>
                                    </li>
                                    <li>
                                        <strong>Consumption Tax 12% :</strong> 
                                        <asp:Label ID="LabelConsumptionTax" runat="server" Text="Php0.00"></asp:Label></li>
                                    <li><strong>Grand - Total Transaction :</strong>
                                        <asp:Label ID="LabelTotalTransaction" runat="server" Text="Php0.00"></asp:Label></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

    <script type="text/javascript">
        function CheckNumeric(e) {

            if (window.event) // IE 
            {
                if ((e.keyCode < 48 || e.keyCode > 57) & e.keyCode != 8) {
                    event.returnValue = false;
                    return false;

                }
            }
            else { // Fire Fox
                if ((e.which < 48 || e.which > 57) & e.which != 8) {
                    e.preventDefault();
                    return false;

                }
            }
        }

    </script>

    <asp:SqlDataSource ID="SqlDataSourceCompanyList" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Companies]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceInvoiceList" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM InvoiceItems WHERE (InvoiceId = @Id)" InsertCommand="INSERT INTO [InvoiceList] ([CompanyName], [DateRange]) VALUES (@CompanyName, @DateRange)" SelectCommand="SELECT * FROM [InvoiceList] ORDER By Id DESC" UpdateCommand="UPDATE [InvoiceList] SET [CompanyName] = @CompanyName, [DateRange] = @DateRange WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:SessionParameter Name="Id" SessionField="DeleteId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="CompanyName" SessionField="CompanyName" Type="String" />
            <asp:SessionParameter Name="DateRange" SessionField="DateRange" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="CompanyName" Type="String" />
            <asp:Parameter Name="DateRange" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceStorageFee" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [InvoiceItems] WHERE [Id] = @Id" InsertCommand="INSERT INTO [InvoiceItems] ([InvoiceId], [ItemType], [Item], [Quantity], [Rate], [Total]) VALUES (@InvoiceId, @ItemType, @Item, @Quantity, @Rate, @Total)" SelectCommand="SELECT Id, InvoiceId, ItemType, Item, Quantity, Rate, Total FROM InvoiceItems WHERE (InvoiceId = @InvoiceId) AND (ItemType = @ItemType)" UpdateCommand="UPDATE [InvoiceItems] SET [Item] = @Item, [Quantity] = @Quantity, [Rate] = @Rate WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="GridViewInvoiceList" Name="InvoiceId" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="DropDownList1" Name="ItemType" PropertyName="SelectedValue" Type="String" />
            <asp:Parameter Name="Item" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
            <asp:Parameter Name="Total" Type="Double" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="GridViewInvoiceList" Name="InvoiceId" PropertyName="SelectedValue" />
            <asp:QueryStringParameter DefaultValue="MonthlyStorageFee" Name="ItemType" QueryStringField="ItemType" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Item" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourceHandlingIn" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [InvoiceItems] WHERE [Id] = @Id" InsertCommand="INSERT INTO [InvoiceItems] ([InvoiceId], [ItemType], [Item], [Quantity], [Rate]) VALUES (@InvoiceId, @ItemType, @Item, @Quantity, @Rate)" SelectCommand="SELECT * FROM [InvoiceItems] WHERE (([InvoiceId] = @InvoiceId) AND ([ItemType] = @ItemType))" UpdateCommand="UPDATE [InvoiceItems] SET  [Item] = @Item, [Quantity] = @Quantity, [Rate] = @Rate WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="GridViewInvoiceList" Name="InvoiceId" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="" Name="ItemType" PropertyName="SelectedValue" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="GridViewInvoiceList" Name="InvoiceId" PropertyName="SelectedValue" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="ItemHandling_HandlingIn" Name="ItemType" QueryStringField="ItemType" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Item" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourceHandlingOut" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [InvoiceItems] WHERE [Id] = @Id" InsertCommand="INSERT INTO [InvoiceItems] ([InvoiceId], [ItemType], [Item], [Quantity], [Rate], [Total]) VALUES (@InvoiceId, @ItemType, @Item, @Quantity, @Rate, @Total)" SelectCommand="SELECT * FROM [InvoiceItems] WHERE (([InvoiceId] = @InvoiceId) AND ([ItemType] = @ItemType))" UpdateCommand="UPDATE [InvoiceItems] SET [Item] = @Item, [Quantity] = @Quantity, [Rate] = @Rate WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="GridViewInvoiceList" Name="InvoiceId" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="DropDownList1" Name="ItemType" PropertyName="SelectedValue" Type="String" />
            <asp:Parameter Name="Item" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
            <asp:Parameter Name="Total" Type="Double" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="GridViewInvoiceList" Name="InvoiceId" PropertyName="SelectedValue" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="ItemHandling_HandlingOut" Name="ItemType" QueryStringField="ItemType" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Item" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourceOthers" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [InvoiceItems] WHERE [Id] = @Id" InsertCommand="INSERT INTO [InvoiceItems] ([InvoiceId], [ItemType], [Item], [Quantity], [Rate], [Total]) VALUES (@InvoiceId, @ItemType, @Item, @Quantity, @Rate, @Total)" SelectCommand="SELECT * FROM [InvoiceItems] WHERE (([InvoiceId] = @InvoiceId) AND ([ItemType] = @ItemType))" UpdateCommand="UPDATE InvoiceItems SET Item = @Item, Quantity = @Quantity, Rate = @Rate WHERE (Id = @Id)">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="GridViewInvoiceList" Name="InvoiceId" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="DropDownList1" Name="ItemType" PropertyName="SelectedValue" Type="String" />
            <asp:Parameter Name="Item" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
            <asp:Parameter Name="Total" Type="Double" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="GridViewInvoiceList" Name="InvoiceId" PropertyName="SelectedValue" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="Others" Name="ItemType" QueryStringField="ItemType" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Item" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>




    <asp:SqlDataSource ID="SqlDataSourceMonthlyStorage" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Department, COUNT(Department) AS Expr1 FROM MasterList WHERE (CompanyCode = @CompanyCode) AND (CreatedDate &lt; @From ) AND (Status = 'IN') GROUP BY Department" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownListCompanyList" Name="CompanyCode" PropertyName="SelectedValue" />
            <asp:SessionParameter Name="From" SessionField="DateRange1" />
            <asp:SessionParameter Name="To" SessionField="DateRange2" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourcePickupBoxNewStorage" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT COUNT(PickUps.Status) AS BoxCount FROM PickUps INNER JOIN TransactionHeaders ON PickUps.TransactionHeaders_id = TransactionHeaders.Id WHERE (PickUps.Status = @Status) AND (PickUps.ModifiedDate &gt; @From OR PickUps.CreatedDate &gt; @From) AND (TransactionHeaders.CompanyCode = @CompanyCode) GROUP BY PickUps.Status, TransactionHeaders.CompanyCode">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="PROCESSED" Name="Status" QueryStringField="Status" />
            <asp:SessionParameter DefaultValue="" Name="From" SessionField="DateRange1" />
            <asp:SessionParameter Name="To" SessionField="DateRange2" />
            <asp:ControlParameter ControlID="DropDownListCompanyList" Name="CompanyCode" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourceInsertInvoice" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [InvoiceList] WHERE [Id] = @Id" InsertCommand="INSERT INTO [InvoiceList] ([CompanyName], [DateRange],[Vat]) VALUES (@CompanyName, @DateRange,@vat) SET @InvoiceId = SCOPE_IDENTITY()" SelectCommand="SELECT * FROM [InvoiceList] ORDER By Id DESC" UpdateCommand="UPDATE [InvoiceList] SET [CompanyName] = @CompanyName, [DateRange] = @DateRange WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="CompanyName" SessionField="CompanyName" Type="String" />
            <asp:SessionParameter Name="DateRange" SessionField="DateRange" Type="String" />
            <asp:Parameter Name="InvoiceId" Type="Int32" Direction="Output" />
            <asp:SessionParameter Name="vat" SessionField="vat" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="CompanyName" Type="String" />
            <asp:Parameter Name="DateRange" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourceHandlingINInsert" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TransactionHeaders.isRush, COUNT(Repickup.TransactionHeaders_id) AS BoxCount FROM TransactionHeaders INNER JOIN Repickup ON TransactionHeaders.Id = Repickup.TransactionHeaders_id WHERE (Repickup.Status = @Status) AND (TransactionHeaders.ModifiedDate BETWEEN @From AND @To ) AND (TransactionHeaders.CompanyCode = @CompanyCode) GROUP BY TransactionHeaders.isRush, Repickup.Status, TransactionHeaders.CompanyCode" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:SessionParameter Name="From" SessionField="DateRange1" />
            <asp:SessionParameter Name="To" SessionField="DateRange2" />
            <asp:QueryStringParameter DefaultValue="PROCESSED" Name="Status" QueryStringField="Status" />
            <asp:ControlParameter ControlID="DropDownListCompanyList" Name="CompanyCode" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourceHandlingOutInsert" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TransactionHeaders.isRush, COUNT(Retrievals.TransactionHeaders_id) AS BoxCount FROM TransactionHeaders INNER JOIN Retrievals ON TransactionHeaders.Id = Retrievals.TransactionHeaders_id WHERE (TransactionHeaders.ModifiedDate BETWEEN @From AND @To ) AND (TransactionHeaders.CompanyCode = @CompanyCode) AND (TransactionHeaders.Status = @Status) GROUP BY TransactionHeaders.isRush, TransactionHeaders.CompanyCode" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:SessionParameter Name="From" SessionField="DateRange1" />
            <asp:SessionParameter Name="To" SessionField="DateRange2" />
            <asp:QueryStringParameter DefaultValue="PROCESSED" Name="Status" QueryStringField="Status" />
            <asp:ControlParameter ControlID="DropDownListCompanyList" Name="CompanyCode" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourceAlerts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (Type = @Type) AND (Status = @Status) AND (Alerts = @Alerts)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:SessionParameter Name="Type" SessionField="AlertType" Type="String" />
            <asp:Parameter DefaultValue="NEW" Name="Status" Type="String" />
            <asp:Parameter DefaultValue="1" Name="Alerts" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceMessages" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, ConvoId, Sender, Message, DateCreated, Status FROM Messages WHERE (Sender &lt;&gt; @Sender) AND (Status = 1) ORDER BY Id DESC" UpdateCommand="UPDATE Messages SET Status = 0 WHERE (ConvoId = @InboxID) AND (Receiver = @Receiver) AND (Status = @Status)">
        <SelectParameters>
            <asp:Parameter DefaultValue="ADMIN" Name="Sender" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="InboxID" SessionField="InboxID" />
            <asp:Parameter DefaultValue="ADMIN" Name="Receiver" />
            <asp:Parameter DefaultValue="1" Name="Status" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourceInsertItem" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [InvoiceItems] WHERE [Id] = @Id" InsertCommand="INSERT INTO [InvoiceItems] ([InvoiceId], [ItemType], [Item], [Quantity], [Rate]) VALUES (@InvoiceId, @ItemType, @Item, @Quantity, @Rate)" SelectCommand="SELECT * FROM [InvoiceItems]" UpdateCommand="UPDATE [InvoiceItems] SET [InvoiceId] = @InvoiceId, [ItemType] = @ItemType, [Item] = @Item, [Quantity] = @Quantity, [Rate] = @Rate, [Total] = @Total WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="InvoiceId" SessionField="InvoiceId" Type="Int32" />
            <asp:SessionParameter Name="ItemType" SessionField="ItemType" Type="String" />
            <asp:SessionParameter Name="Item" SessionField="Item" Type="String" />
            <asp:SessionParameter Name="Quantity" SessionField="Quantity" Type="Int32" />
            <asp:SessionParameter Name="Rate" SessionField="Rate" Type="Double" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="InvoiceId" Type="Int32" />
            <asp:Parameter Name="ItemType" Type="String" />
            <asp:Parameter Name="Item" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
            <asp:Parameter Name="Total" Type="Double" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceVat" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [InvoiceList] WHERE [Id] = @Id" InsertCommand="INSERT INTO [InvoiceList] ([CompanyName], [DateRange], [Vat]) VALUES (@CompanyName, @DateRange, @Vat)" SelectCommand="SELECT * FROM [InvoiceList]" UpdateCommand="UPDATE [InvoiceList] SET[Vat] = @Vat WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CompanyName" Type="String" />
            <asp:Parameter Name="DateRange" Type="String" />
            <asp:Parameter Name="Vat" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="Vat" SessionField="vat" />
            <asp:ControlParameter ControlID="GridViewInvoiceList" Name="Id" PropertyName="SelectedValue" />
        </UpdateParameters>
    </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="SqlDataSourceUserLoginAlert" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, [User], DateLogin, Alerts FROM UserLogins WHERE (Alerts = @Alerts) ORDER BY DateLogin DESC" DataSourceMode="DataReader">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="1" Name="Alerts" />
                                            </SelectParameters>
                                     </asp:SqlDataSource>

                                 </asp:Content>
