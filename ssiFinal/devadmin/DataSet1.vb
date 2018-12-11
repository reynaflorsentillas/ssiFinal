Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.CodeDom.Compiler
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Data
Imports System.Diagnostics
Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization
Imports System.Threading
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Namespace ssiFinal
	<DesignerCategory("code")>
	<HelpKeyword("vs.data.DataSet")>
	<Serializable>
	<ToolboxItem(True)>
	<XmlRoot("DataSet1")>
	<XmlSchemaProvider("GetTypedDataSetSchema")>
	Public Class DataSet1
		Inherits DataSet
		Private tableTransactions As DataSet1.TransactionsDataTable

		Private tableProcessedPickupTransactionsItems As DataSet1.ProcessedPickupTransactionsItemsDataTable

		Private tableProcessedRepickupTransactionsItems As DataSet1.ProcessedRepickupTransactionsItemsDataTable

		Private tableSalesRevenue As DataSet1.SalesRevenueDataTable

		Private tableSalesRevenue2 As DataSet1.SalesRevenue2DataTable

		Private tableSpaceUtilization As DataSet1.SpaceUtilizationDataTable

		Private _schemaSerializationMode As System.Data.SchemaSerializationMode

		<Browsable(False)>
		<DebuggerNonUserCode>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public ReadOnly Property ProcessedPickupTransactionsItems As DataSet1.ProcessedPickupTransactionsItemsDataTable
			Get
				Return Me.tableProcessedPickupTransactionsItems
			End Get
		End Property

		<Browsable(False)>
		<DebuggerNonUserCode>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public ReadOnly Property ProcessedRepickupTransactionsItems As DataSet1.ProcessedRepickupTransactionsItemsDataTable
			Get
				Return Me.tableProcessedRepickupTransactionsItems
			End Get
		End Property

		<DebuggerNonUserCode>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Shadows ReadOnly Property Relations As DataRelationCollection
			Get
				Return MyBase.Relations
			End Get
		End Property

		<Browsable(False)>
		<DebuggerNonUserCode>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public ReadOnly Property SalesRevenue As DataSet1.SalesRevenueDataTable
			Get
				Return Me.tableSalesRevenue
			End Get
		End Property

		<Browsable(False)>
		<DebuggerNonUserCode>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public ReadOnly Property SalesRevenue2 As DataSet1.SalesRevenue2DataTable
			Get
				Return Me.tableSalesRevenue2
			End Get
		End Property

		<Browsable(True)>
		<DebuggerNonUserCode>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Overrides Property SchemaSerializationMode As System.Data.SchemaSerializationMode
			Get
				Return Me._schemaSerializationMode
			End Get
			Set(ByVal value As System.Data.SchemaSerializationMode)
				Me._schemaSerializationMode = value
			End Set
		End Property

		<Browsable(False)>
		<DebuggerNonUserCode>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public ReadOnly Property SpaceUtilization As DataSet1.SpaceUtilizationDataTable
			Get
				Return Me.tableSpaceUtilization
			End Get
		End Property

		<DebuggerNonUserCode>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Shadows ReadOnly Property Tables As DataTableCollection
			Get
				Return MyBase.Tables
			End Get
		End Property

		<Browsable(False)>
		<DebuggerNonUserCode>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public ReadOnly Property Transactions As DataSet1.TransactionsDataTable
			Get
				Return Me.tableTransactions
			End Get
		End Property

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Sub New()
			MyBase.New()
			Me._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
			MyBase.BeginInit()
			Me.InitClass()
			Dim collectionChangeEventHandler As System.ComponentModel.CollectionChangeEventHandler = New System.ComponentModel.CollectionChangeEventHandler(AddressOf Me.SchemaChanged)
			AddHandler MyBase.Tables.CollectionChanged,  collectionChangeEventHandler
			AddHandler MyBase.Relations.CollectionChanged,  collectionChangeEventHandler
			MyBase.EndInit()
		End Sub

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
			MyBase.New(info, context, False)
			Me._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
			If (MyBase.IsBinarySerialized(info, context)) Then
				Me.InitVars(False)
				Dim collectionChangeEventHandler As System.ComponentModel.CollectionChangeEventHandler = New System.ComponentModel.CollectionChangeEventHandler(AddressOf Me.SchemaChanged)
				AddHandler Me.Tables.CollectionChanged,  collectionChangeEventHandler
				AddHandler Me.Relations.CollectionChanged,  collectionChangeEventHandler
				Return
			End If
			Dim str As String = Conversions.ToString(info.GetValue("XmlSchema", GetType(String)))
			If (MyBase.DetermineSchemaSerializationMode(info, context) <> System.Data.SchemaSerializationMode.IncludeSchema) Then
				MyBase.ReadXmlSchema(New XmlTextReader(New StringReader(str)))
			Else
				Dim dataSet As System.Data.DataSet = New System.Data.DataSet()
				dataSet.ReadXmlSchema(New XmlTextReader(New StringReader(str)))
				If (dataSet.Tables("Transactions") IsNot Nothing) Then
					MyBase.Tables.Add(New DataSet1.TransactionsDataTable(dataSet.Tables("Transactions")))
				End If
				If (dataSet.Tables("ProcessedPickupTransactionsItems") IsNot Nothing) Then
					MyBase.Tables.Add(New DataSet1.ProcessedPickupTransactionsItemsDataTable(dataSet.Tables("ProcessedPickupTransactionsItems")))
				End If
				If (dataSet.Tables("ProcessedRepickupTransactionsItems") IsNot Nothing) Then
					MyBase.Tables.Add(New DataSet1.ProcessedRepickupTransactionsItemsDataTable(dataSet.Tables("ProcessedRepickupTransactionsItems")))
				End If
				If (dataSet.Tables("SalesRevenue") IsNot Nothing) Then
					MyBase.Tables.Add(New DataSet1.SalesRevenueDataTable(dataSet.Tables("SalesRevenue")))
				End If
				If (dataSet.Tables("SalesRevenue2") IsNot Nothing) Then
					MyBase.Tables.Add(New DataSet1.SalesRevenue2DataTable(dataSet.Tables("SalesRevenue2")))
				End If
				If (dataSet.Tables("SpaceUtilization") IsNot Nothing) Then
					MyBase.Tables.Add(New DataSet1.SpaceUtilizationDataTable(dataSet.Tables("SpaceUtilization")))
				End If
				MyBase.DataSetName = dataSet.DataSetName
				MyBase.Prefix = dataSet.Prefix
				MyBase.[Namespace] = dataSet.[Namespace]
				MyBase.Locale = dataSet.Locale
				MyBase.CaseSensitive = dataSet.CaseSensitive
				MyBase.EnforceConstraints = dataSet.EnforceConstraints
				MyBase.Merge(dataSet, False, MissingSchemaAction.Add)
				Me.InitVars()
			End If
			MyBase.GetSerializationData(info, context)
			Dim collectionChangeEventHandler1 As System.ComponentModel.CollectionChangeEventHandler = New System.ComponentModel.CollectionChangeEventHandler(AddressOf Me.SchemaChanged)
			AddHandler MyBase.Tables.CollectionChanged,  collectionChangeEventHandler1
			AddHandler Me.Relations.CollectionChanged,  collectionChangeEventHandler1
		End Sub

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Overrides Function Clone() As DataSet
			Dim schemaSerializationMode As DataSet1 = DirectCast(MyBase.Clone(), DataSet1)
			schemaSerializationMode.InitVars()
			schemaSerializationMode.SchemaSerializationMode = Me.SchemaSerializationMode
			Return schemaSerializationMode
		End Function

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Protected Overrides Function GetSchemaSerializable() As System.Xml.Schema.XmlSchema
			Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
			MyBase.WriteXmlSchema(New XmlTextWriter(memoryStream, Nothing))
			memoryStream.Position = CLng(0)
			Return System.Xml.Schema.XmlSchema.Read(New XmlTextReader(memoryStream), Nothing)
		End Function

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Shared Function GetTypedDataSetSchema(ByVal xs As XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
			Dim xmlSchemaComplexType As System.Xml.Schema.XmlSchemaComplexType
			Dim dataSet1 As ssiFinal.DataSet1 = New ssiFinal.DataSet1()
			Dim xmlSchemaComplexType1 As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType()
			Dim xmlSchemaSequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence()
			Dim xmlSchemaAny As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny() With
			{
				.[Namespace] = dataSet1.[Namespace]
			}
			xmlSchemaSequence.Items.Add(xmlSchemaAny)
			xmlSchemaComplexType1.Particle = xmlSchemaSequence
			Dim schemaSerializable As System.Xml.Schema.XmlSchema = dataSet1.GetSchemaSerializable()
			If (xs.Contains(schemaSerializable.TargetNamespace)) Then
				Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
				Dim memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream()
				Try
					schemaSerializable.Write(memoryStream)
					Dim enumerator As IEnumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator()
					While enumerator.MoveNext()
						Dim current As System.Xml.Schema.XmlSchema = DirectCast(enumerator.Current, System.Xml.Schema.XmlSchema)
						memoryStream1.SetLength(CLng(0))
						current.Write(memoryStream1)
						If (memoryStream.Length <> memoryStream1.Length) Then
							Continue While
						End If
						memoryStream.Position = CLng(0)
						memoryStream1.Position = CLng(0)
						While memoryStream.Position <> memoryStream.Length AndAlso memoryStream.ReadByte() = memoryStream1.ReadByte()
						End While
						If (memoryStream.Position <> memoryStream.Length) Then
							Continue While
						End If
						xmlSchemaComplexType = xmlSchemaComplexType1
						Return xmlSchemaComplexType
					End While
				Finally
					If (memoryStream IsNot Nothing) Then
						memoryStream.Close()
					End If
					If (memoryStream1 IsNot Nothing) Then
						memoryStream1.Close()
					End If
				End Try
			End If
			xs.Add(schemaSerializable)
			xmlSchemaComplexType = xmlSchemaComplexType1
			Return xmlSchemaComplexType
		End Function

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Private Sub InitClass()
			MyBase.DataSetName = "DataSet1"
			MyBase.Prefix = ""
			MyBase.[Namespace] = "http://tempuri.org/DataSet1.xsd"
			MyBase.EnforceConstraints = True
			Me.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
			Me.tableTransactions = New DataSet1.TransactionsDataTable()
			MyBase.Tables.Add(Me.tableTransactions)
			Me.tableProcessedPickupTransactionsItems = New DataSet1.ProcessedPickupTransactionsItemsDataTable()
			MyBase.Tables.Add(Me.tableProcessedPickupTransactionsItems)
			Me.tableProcessedRepickupTransactionsItems = New DataSet1.ProcessedRepickupTransactionsItemsDataTable()
			MyBase.Tables.Add(Me.tableProcessedRepickupTransactionsItems)
			Me.tableSalesRevenue = New DataSet1.SalesRevenueDataTable()
			MyBase.Tables.Add(Me.tableSalesRevenue)
			Me.tableSalesRevenue2 = New DataSet1.SalesRevenue2DataTable()
			MyBase.Tables.Add(Me.tableSalesRevenue2)
			Me.tableSpaceUtilization = New DataSet1.SpaceUtilizationDataTable()
			MyBase.Tables.Add(Me.tableSpaceUtilization)
		End Sub

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Protected Overrides Sub InitializeDerivedDataSet()
			MyBase.BeginInit()
			Me.InitClass()
			MyBase.EndInit()
		End Sub

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Friend Sub InitVars()
			Me.InitVars(True)
		End Sub

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Friend Sub InitVars(ByVal initTable As Boolean)
			Me.tableTransactions = DirectCast(MyBase.Tables("Transactions"), DataSet1.TransactionsDataTable)
			If (initTable AndAlso Me.tableTransactions IsNot Nothing) Then
				Me.tableTransactions.InitVars()
			End If
			Me.tableProcessedPickupTransactionsItems = DirectCast(MyBase.Tables("ProcessedPickupTransactionsItems"), DataSet1.ProcessedPickupTransactionsItemsDataTable)
			If (initTable AndAlso Me.tableProcessedPickupTransactionsItems IsNot Nothing) Then
				Me.tableProcessedPickupTransactionsItems.InitVars()
			End If
			Me.tableProcessedRepickupTransactionsItems = DirectCast(MyBase.Tables("ProcessedRepickupTransactionsItems"), DataSet1.ProcessedRepickupTransactionsItemsDataTable)
			If (initTable AndAlso Me.tableProcessedRepickupTransactionsItems IsNot Nothing) Then
				Me.tableProcessedRepickupTransactionsItems.InitVars()
			End If
			Me.tableSalesRevenue = DirectCast(MyBase.Tables("SalesRevenue"), DataSet1.SalesRevenueDataTable)
			If (initTable AndAlso Me.tableSalesRevenue IsNot Nothing) Then
				Me.tableSalesRevenue.InitVars()
			End If
			Me.tableSalesRevenue2 = DirectCast(MyBase.Tables("SalesRevenue2"), DataSet1.SalesRevenue2DataTable)
			If (initTable AndAlso Me.tableSalesRevenue2 IsNot Nothing) Then
				Me.tableSalesRevenue2.InitVars()
			End If
			Me.tableSpaceUtilization = DirectCast(MyBase.Tables("SpaceUtilization"), DataSet1.SpaceUtilizationDataTable)
			If (initTable AndAlso Me.tableSpaceUtilization IsNot Nothing) Then
				Me.tableSpaceUtilization.InitVars()
			End If
		End Sub

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Protected Overrides Sub ReadXmlSerializable(ByVal reader As XmlReader)
			If (MyBase.DetermineSchemaSerializationMode(reader) <> System.Data.SchemaSerializationMode.IncludeSchema) Then
				MyBase.ReadXml(reader)
				Me.InitVars()
				Return
			End If
			Me.Reset()
			Dim dataSet As System.Data.DataSet = New System.Data.DataSet()
			dataSet.ReadXml(reader)
			If (dataSet.Tables("Transactions") IsNot Nothing) Then
				MyBase.Tables.Add(New DataSet1.TransactionsDataTable(dataSet.Tables("Transactions")))
			End If
			If (dataSet.Tables("ProcessedPickupTransactionsItems") IsNot Nothing) Then
				MyBase.Tables.Add(New DataSet1.ProcessedPickupTransactionsItemsDataTable(dataSet.Tables("ProcessedPickupTransactionsItems")))
			End If
			If (dataSet.Tables("ProcessedRepickupTransactionsItems") IsNot Nothing) Then
				MyBase.Tables.Add(New DataSet1.ProcessedRepickupTransactionsItemsDataTable(dataSet.Tables("ProcessedRepickupTransactionsItems")))
			End If
			If (dataSet.Tables("SalesRevenue") IsNot Nothing) Then
				MyBase.Tables.Add(New DataSet1.SalesRevenueDataTable(dataSet.Tables("SalesRevenue")))
			End If
			If (dataSet.Tables("SalesRevenue2") IsNot Nothing) Then
				MyBase.Tables.Add(New DataSet1.SalesRevenue2DataTable(dataSet.Tables("SalesRevenue2")))
			End If
			If (dataSet.Tables("SpaceUtilization") IsNot Nothing) Then
				MyBase.Tables.Add(New DataSet1.SpaceUtilizationDataTable(dataSet.Tables("SpaceUtilization")))
			End If
			MyBase.DataSetName = dataSet.DataSetName
			MyBase.Prefix = dataSet.Prefix
			MyBase.[Namespace] = dataSet.[Namespace]
			MyBase.Locale = dataSet.Locale
			MyBase.CaseSensitive = dataSet.CaseSensitive
			MyBase.EnforceConstraints = dataSet.EnforceConstraints
			MyBase.Merge(dataSet, False, MissingSchemaAction.Add)
			Me.InitVars()
		End Sub

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Private Sub SchemaChanged(ByVal sender As Object, ByVal e As CollectionChangeEventArgs)
			If (e.Action = CollectionChangeAction.Remove) Then
				Me.InitVars()
			End If
		End Sub

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Private Function ShouldSerializeProcessedPickupTransactionsItems() As Boolean
			Return False
		End Function

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Private Function ShouldSerializeProcessedRepickupTransactionsItems() As Boolean
			Return False
		End Function

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Protected Overrides Function ShouldSerializeRelations() As Boolean
			Return False
		End Function

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Private Function ShouldSerializeSalesRevenue() As Boolean
			Return False
		End Function

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Private Function ShouldSerializeSalesRevenue2() As Boolean
			Return False
		End Function

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Private Function ShouldSerializeSpaceUtilization() As Boolean
			Return False
		End Function

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Protected Overrides Function ShouldSerializeTables() As Boolean
			Return False
		End Function

		<DebuggerNonUserCode>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Private Function ShouldSerializeTransactions() As Boolean
			Return False
		End Function

		<Serializable>
		<XmlSchemaProvider("GetTypedTableSchema")>
		Public Class ProcessedPickupTransactionsItemsDataTable
			Inherits TypedTableBase(Of DataSet1.ProcessedPickupTransactionsItemsRow)
			Private columnBarCode As DataColumn

			Private columnQRCode As DataColumn

			Private columnDepartment As DataColumn

			Private columnBoxNumber As DataColumn

			Private columnDescription As DataColumn

			Private columnRetention As DataColumn

			Private columnStatus As DataColumn

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property BarCodeColumn As DataColumn
				Get
					Return Me.columnBarCode
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property BoxNumberColumn As DataColumn
				Get
					Return Me.columnBoxNumber
				End Get
			End Property

			<Browsable(False)>
			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property DepartmentColumn As DataColumn
				Get
					Return Me.columnDepartment
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property DescriptionColumn As DataColumn
				Get
					Return Me.columnDescription
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Default Public ReadOnly Property Item(ByVal index As Integer) As DataSet1.ProcessedPickupTransactionsItemsRow
				Get
					Return DirectCast(MyBase.Rows(index), DataSet1.ProcessedPickupTransactionsItemsRow)
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property QRCodeColumn As DataColumn
				Get
					Return Me.columnQRCode
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property RetentionColumn As DataColumn
				Get
					Return Me.columnRetention
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property StatusColumn As DataColumn
				Get
					Return Me.columnStatus
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub New()
				MyBase.New()
				MyBase.TableName = "ProcessedPickupTransactionsItems"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub New(ByVal table As DataTable)
				MyBase.New()
				MyBase.TableName = table.TableName
				If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
					MyBase.CaseSensitive = table.CaseSensitive
				End If
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Locale.ToString(), table.DataSet.Locale.ToString(), False) <> 0) Then
					MyBase.Locale = table.Locale
				End If
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.[Namespace], table.DataSet.[Namespace], False) <> 0) Then
					MyBase.[Namespace] = table.[Namespace]
				End If
				MyBase.Prefix = table.Prefix
				MyBase.MinimumCapacity = table.MinimumCapacity
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub AddProcessedPickupTransactionsItemsRow(ByVal row As DataSet1.ProcessedPickupTransactionsItemsRow)
				MyBase.Rows.Add(row)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function AddProcessedPickupTransactionsItemsRow(ByVal BarCode As String, ByVal QRCode As String, ByVal Department As String, ByVal BoxNumber As String, ByVal Description As String, ByVal Retention As String, ByVal Status As String) As DataSet1.ProcessedPickupTransactionsItemsRow
				Dim processedPickupTransactionsItemsRow As DataSet1.ProcessedPickupTransactionsItemsRow = DirectCast(MyBase.NewRow(), DataSet1.ProcessedPickupTransactionsItemsRow)
				processedPickupTransactionsItemsRow.ItemArray = New Object() { BarCode, QRCode, Department, BoxNumber, Description, Retention, Status }
				MyBase.Rows.Add(processedPickupTransactionsItemsRow)
				Return processedPickupTransactionsItemsRow
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim processedPickupTransactionsItemsDataTable As DataSet1.ProcessedPickupTransactionsItemsDataTable = DirectCast(MyBase.Clone(), DataSet1.ProcessedPickupTransactionsItemsDataTable)
				processedPickupTransactionsItemsDataTable.InitVars()
				Return processedPickupTransactionsItemsDataTable
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSet1.ProcessedPickupTransactionsItemsDataTable()
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSet1.ProcessedPickupTransactionsItemsRow)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Shared Function GetTypedTableSchema(ByVal xs As XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
				Dim xmlSchemaComplexType As System.Xml.Schema.XmlSchemaComplexType
				Dim xmlSchemaComplexType1 As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType()
				Dim xmlSchemaSequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence()
				Dim dataSet1 As ssiFinal.DataSet1 = New ssiFinal.DataSet1()
				Dim xmlSchemaAny As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny() With
				{
					.[Namespace] = "http://www.w3.org/2001/XMLSchema",
					.MinOccurs = New Decimal(0),
					.MaxOccurs = New Decimal(-1, -1, -1, False, 0),
					.ProcessContents = XmlSchemaContentProcessing.Lax
				}
				xmlSchemaSequence.Items.Add(xmlSchemaAny)
				Dim xmlSchemaAny1 As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny() With
				{
					.[Namespace] = "urn:schemas-microsoft-com:xml-diffgram-v1",
					.MinOccurs = New Decimal(1),
					.ProcessContents = XmlSchemaContentProcessing.Lax
				}
				xmlSchemaSequence.Items.Add(xmlSchemaAny1)
				Dim xmlSchemaAttribute As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute() With
				{
					.Name = "namespace",
					.FixedValue = dataSet1.[Namespace]
				}
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute1 As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute() With
				{
					.Name = "tableTypeName",
					.FixedValue = "ProcessedPickupTransactionsItemsDataTable"
				}
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1)
				xmlSchemaComplexType1.Particle = xmlSchemaSequence
				Dim schemaSerializable As System.Xml.Schema.XmlSchema = dataSet1.GetSchemaSerializable()
				If (xs.Contains(schemaSerializable.TargetNamespace)) Then
					Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
					Dim memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream()
					Try
						schemaSerializable.Write(memoryStream)
						Dim enumerator As IEnumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator()
						While enumerator.MoveNext()
							Dim current As System.Xml.Schema.XmlSchema = DirectCast(enumerator.Current, System.Xml.Schema.XmlSchema)
							memoryStream1.SetLength(CLng(0))
							current.Write(memoryStream1)
							If (memoryStream.Length <> memoryStream1.Length) Then
								Continue While
							End If
							memoryStream.Position = CLng(0)
							memoryStream1.Position = CLng(0)
							While memoryStream.Position <> memoryStream.Length AndAlso memoryStream.ReadByte() = memoryStream1.ReadByte()
							End While
							If (memoryStream.Position <> memoryStream.Length) Then
								Continue While
							End If
							xmlSchemaComplexType = xmlSchemaComplexType1
							Return xmlSchemaComplexType
						End While
					Finally
						If (memoryStream IsNot Nothing) Then
							memoryStream.Close()
						End If
						If (memoryStream1 IsNot Nothing) Then
							memoryStream1.Close()
						End If
					End Try
				End If
				xs.Add(schemaSerializable)
				xmlSchemaComplexType = xmlSchemaComplexType1
				Return xmlSchemaComplexType
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Private Sub InitClass()
				Me.columnBarCode = New DataColumn("BarCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBarCode)
				Me.columnQRCode = New DataColumn("QRCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnQRCode)
				Me.columnDepartment = New DataColumn("Department", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDepartment)
				Me.columnBoxNumber = New DataColumn("BoxNumber", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBoxNumber)
				Me.columnDescription = New DataColumn("Description", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDescription)
				Me.columnRetention = New DataColumn("Retention", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnRetention)
				Me.columnStatus = New DataColumn("Status", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnStatus)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub InitVars()
				Me.columnBarCode = MyBase.Columns("BarCode")
				Me.columnQRCode = MyBase.Columns("QRCode")
				Me.columnDepartment = MyBase.Columns("Department")
				Me.columnBoxNumber = MyBase.Columns("BoxNumber")
				Me.columnDescription = MyBase.Columns("Description")
				Me.columnRetention = MyBase.Columns("Retention")
				Me.columnStatus = MyBase.Columns("Status")
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function NewProcessedPickupTransactionsItemsRow() As DataSet1.ProcessedPickupTransactionsItemsRow
				Return DirectCast(MyBase.NewRow(), DataSet1.ProcessedPickupTransactionsItemsRow)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
				Return New DataSet1.ProcessedPickupTransactionsItemsRow(builder)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/ProcessedPickupTransactionsItemsDataTable::OnRowChanged(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowChanged(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/ProcessedPickupTransactionsItemsDataTable::OnRowChanging(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowChanging(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/ProcessedPickupTransactionsItemsDataTable::OnRowDeleted(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowDeleted(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/ProcessedPickupTransactionsItemsDataTable::OnRowDeleting(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowDeleting(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub RemoveProcessedPickupTransactionsItemsRow(ByVal row As DataSet1.ProcessedPickupTransactionsItemsRow)
				MyBase.Rows.Remove(row)
			End Sub

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event ProcessedPickupTransactionsItemsRowChanged As DataSet1.ProcessedPickupTransactionsItemsRowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event ProcessedPickupTransactionsItemsRowChanging As DataSet1.ProcessedPickupTransactionsItemsRowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event ProcessedPickupTransactionsItemsRowDeleted As DataSet1.ProcessedPickupTransactionsItemsRowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event ProcessedPickupTransactionsItemsRowDeleting As DataSet1.ProcessedPickupTransactionsItemsRowChangeEventHandler
		End Class

		Public Class ProcessedPickupTransactionsItemsRow
			Inherits DataRow
			Private tableProcessedPickupTransactionsItems As DataSet1.ProcessedPickupTransactionsItemsDataTable

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property BarCode As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableProcessedPickupTransactionsItems.BarCodeColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'BarCode' in table 'ProcessedPickupTransactionsItems' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableProcessedPickupTransactionsItems.BarCodeColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property BoxNumber As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableProcessedPickupTransactionsItems.BoxNumberColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'BoxNumber' in table 'ProcessedPickupTransactionsItems' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableProcessedPickupTransactionsItems.BoxNumberColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property Department As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableProcessedPickupTransactionsItems.DepartmentColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'Department' in table 'ProcessedPickupTransactionsItems' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableProcessedPickupTransactionsItems.DepartmentColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property Description As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableProcessedPickupTransactionsItems.DescriptionColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'Description' in table 'ProcessedPickupTransactionsItems' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableProcessedPickupTransactionsItems.DescriptionColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property QRCode As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableProcessedPickupTransactionsItems.QRCodeColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'QRCode' in table 'ProcessedPickupTransactionsItems' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableProcessedPickupTransactionsItems.QRCodeColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property Retention As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableProcessedPickupTransactionsItems.RetentionColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'Retention' in table 'ProcessedPickupTransactionsItems' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableProcessedPickupTransactionsItems.RetentionColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property Status As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableProcessedPickupTransactionsItems.StatusColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'Status' in table 'ProcessedPickupTransactionsItems' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableProcessedPickupTransactionsItems.StatusColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub New(ByVal rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableProcessedPickupTransactionsItems = DirectCast(MyBase.Table, DataSet1.ProcessedPickupTransactionsItemsDataTable)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsBarCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableProcessedPickupTransactionsItems.BarCodeColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsBoxNumberNull() As Boolean
				Return MyBase.IsNull(Me.tableProcessedPickupTransactionsItems.BoxNumberColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsDepartmentNull() As Boolean
				Return MyBase.IsNull(Me.tableProcessedPickupTransactionsItems.DepartmentColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsDescriptionNull() As Boolean
				Return MyBase.IsNull(Me.tableProcessedPickupTransactionsItems.DescriptionColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsQRCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableProcessedPickupTransactionsItems.QRCodeColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsRetentionNull() As Boolean
				Return MyBase.IsNull(Me.tableProcessedPickupTransactionsItems.RetentionColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsStatusNull() As Boolean
				Return MyBase.IsNull(Me.tableProcessedPickupTransactionsItems.StatusColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetBarCodeNull()
				MyBase.Item(Me.tableProcessedPickupTransactionsItems.BarCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetBoxNumberNull()
				MyBase.Item(Me.tableProcessedPickupTransactionsItems.BoxNumberColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetDepartmentNull()
				MyBase.Item(Me.tableProcessedPickupTransactionsItems.DepartmentColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetDescriptionNull()
				MyBase.Item(Me.tableProcessedPickupTransactionsItems.DescriptionColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetQRCodeNull()
				MyBase.Item(Me.tableProcessedPickupTransactionsItems.QRCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetRetentionNull()
				MyBase.Item(Me.tableProcessedPickupTransactionsItems.RetentionColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetStatusNull()
				MyBase.Item(Me.tableProcessedPickupTransactionsItems.StatusColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub
		End Class

		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Class ProcessedPickupTransactionsItemsRowChangeEvent
			Inherits EventArgs
			Private eventRow As DataSet1.ProcessedPickupTransactionsItemsRow

			Private eventAction As DataRowAction

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Row As DataSet1.ProcessedPickupTransactionsItemsRow
				Get
					Return Me.eventRow
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub New(ByVal row As DataSet1.ProcessedPickupTransactionsItemsRow, ByVal action As DataRowAction)
				MyBase.New()
				Me.eventRow = row
				Me.eventAction = action
			End Sub
		End Class

		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Delegate Sub ProcessedPickupTransactionsItemsRowChangeEventHandler(ByVal sender As Object, ByVal e As DataSet1.ProcessedPickupTransactionsItemsRowChangeEvent)

		<Serializable>
		<XmlSchemaProvider("GetTypedTableSchema")>
		Public Class ProcessedRepickupTransactionsItemsDataTable
			Inherits TypedTableBase(Of DataSet1.ProcessedRepickupTransactionsItemsRow)
			Private columnBarCode As DataColumn

			Private columnBoxNumber As DataColumn

			Private columnDescription As DataColumn

			Private columnLocationCode As DataColumn

			Private columnDestruction As DataColumn

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property BarCodeColumn As DataColumn
				Get
					Return Me.columnBarCode
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property BoxNumberColumn As DataColumn
				Get
					Return Me.columnBoxNumber
				End Get
			End Property

			<Browsable(False)>
			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property DescriptionColumn As DataColumn
				Get
					Return Me.columnDescription
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property DestructionColumn As DataColumn
				Get
					Return Me.columnDestruction
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Default Public ReadOnly Property Item(ByVal index As Integer) As DataSet1.ProcessedRepickupTransactionsItemsRow
				Get
					Return DirectCast(MyBase.Rows(index), DataSet1.ProcessedRepickupTransactionsItemsRow)
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property LocationCodeColumn As DataColumn
				Get
					Return Me.columnLocationCode
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub New()
				MyBase.New()
				MyBase.TableName = "ProcessedRepickupTransactionsItems"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub New(ByVal table As DataTable)
				MyBase.New()
				MyBase.TableName = table.TableName
				If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
					MyBase.CaseSensitive = table.CaseSensitive
				End If
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Locale.ToString(), table.DataSet.Locale.ToString(), False) <> 0) Then
					MyBase.Locale = table.Locale
				End If
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.[Namespace], table.DataSet.[Namespace], False) <> 0) Then
					MyBase.[Namespace] = table.[Namespace]
				End If
				MyBase.Prefix = table.Prefix
				MyBase.MinimumCapacity = table.MinimumCapacity
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub AddProcessedRepickupTransactionsItemsRow(ByVal row As DataSet1.ProcessedRepickupTransactionsItemsRow)
				MyBase.Rows.Add(row)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function AddProcessedRepickupTransactionsItemsRow(ByVal BarCode As String, ByVal BoxNumber As String, ByVal Description As String, ByVal LocationCode As String, ByVal Destruction As String) As DataSet1.ProcessedRepickupTransactionsItemsRow
				Dim processedRepickupTransactionsItemsRow As DataSet1.ProcessedRepickupTransactionsItemsRow = DirectCast(MyBase.NewRow(), DataSet1.ProcessedRepickupTransactionsItemsRow)
				processedRepickupTransactionsItemsRow.ItemArray = New Object() { BarCode, BoxNumber, Description, LocationCode, Destruction }
				MyBase.Rows.Add(processedRepickupTransactionsItemsRow)
				Return processedRepickupTransactionsItemsRow
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim processedRepickupTransactionsItemsDataTable As DataSet1.ProcessedRepickupTransactionsItemsDataTable = DirectCast(MyBase.Clone(), DataSet1.ProcessedRepickupTransactionsItemsDataTable)
				processedRepickupTransactionsItemsDataTable.InitVars()
				Return processedRepickupTransactionsItemsDataTable
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSet1.ProcessedRepickupTransactionsItemsDataTable()
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSet1.ProcessedRepickupTransactionsItemsRow)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Shared Function GetTypedTableSchema(ByVal xs As XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
				Dim xmlSchemaComplexType As System.Xml.Schema.XmlSchemaComplexType
				Dim xmlSchemaComplexType1 As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType()
				Dim xmlSchemaSequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence()
				Dim dataSet1 As ssiFinal.DataSet1 = New ssiFinal.DataSet1()
				Dim xmlSchemaAny As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny() With
				{
					.[Namespace] = "http://www.w3.org/2001/XMLSchema",
					.MinOccurs = New Decimal(0),
					.MaxOccurs = New Decimal(-1, -1, -1, False, 0),
					.ProcessContents = XmlSchemaContentProcessing.Lax
				}
				xmlSchemaSequence.Items.Add(xmlSchemaAny)
				Dim xmlSchemaAny1 As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny() With
				{
					.[Namespace] = "urn:schemas-microsoft-com:xml-diffgram-v1",
					.MinOccurs = New Decimal(1),
					.ProcessContents = XmlSchemaContentProcessing.Lax
				}
				xmlSchemaSequence.Items.Add(xmlSchemaAny1)
				Dim xmlSchemaAttribute As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute() With
				{
					.Name = "namespace",
					.FixedValue = dataSet1.[Namespace]
				}
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute1 As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute() With
				{
					.Name = "tableTypeName",
					.FixedValue = "ProcessedRepickupTransactionsItemsDataTable"
				}
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1)
				xmlSchemaComplexType1.Particle = xmlSchemaSequence
				Dim schemaSerializable As System.Xml.Schema.XmlSchema = dataSet1.GetSchemaSerializable()
				If (xs.Contains(schemaSerializable.TargetNamespace)) Then
					Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
					Dim memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream()
					Try
						schemaSerializable.Write(memoryStream)
						Dim enumerator As IEnumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator()
						While enumerator.MoveNext()
							Dim current As System.Xml.Schema.XmlSchema = DirectCast(enumerator.Current, System.Xml.Schema.XmlSchema)
							memoryStream1.SetLength(CLng(0))
							current.Write(memoryStream1)
							If (memoryStream.Length <> memoryStream1.Length) Then
								Continue While
							End If
							memoryStream.Position = CLng(0)
							memoryStream1.Position = CLng(0)
							While memoryStream.Position <> memoryStream.Length AndAlso memoryStream.ReadByte() = memoryStream1.ReadByte()
							End While
							If (memoryStream.Position <> memoryStream.Length) Then
								Continue While
							End If
							xmlSchemaComplexType = xmlSchemaComplexType1
							Return xmlSchemaComplexType
						End While
					Finally
						If (memoryStream IsNot Nothing) Then
							memoryStream.Close()
						End If
						If (memoryStream1 IsNot Nothing) Then
							memoryStream1.Close()
						End If
					End Try
				End If
				xs.Add(schemaSerializable)
				xmlSchemaComplexType = xmlSchemaComplexType1
				Return xmlSchemaComplexType
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Private Sub InitClass()
				Me.columnBarCode = New DataColumn("BarCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBarCode)
				Me.columnBoxNumber = New DataColumn("BoxNumber", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBoxNumber)
				Me.columnDescription = New DataColumn("Description", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDescription)
				Me.columnLocationCode = New DataColumn("LocationCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnLocationCode)
				Me.columnDestruction = New DataColumn("Destruction", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDestruction)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub InitVars()
				Me.columnBarCode = MyBase.Columns("BarCode")
				Me.columnBoxNumber = MyBase.Columns("BoxNumber")
				Me.columnDescription = MyBase.Columns("Description")
				Me.columnLocationCode = MyBase.Columns("LocationCode")
				Me.columnDestruction = MyBase.Columns("Destruction")
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function NewProcessedRepickupTransactionsItemsRow() As DataSet1.ProcessedRepickupTransactionsItemsRow
				Return DirectCast(MyBase.NewRow(), DataSet1.ProcessedRepickupTransactionsItemsRow)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
				Return New DataSet1.ProcessedRepickupTransactionsItemsRow(builder)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/ProcessedRepickupTransactionsItemsDataTable::OnRowChanged(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowChanged(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/ProcessedRepickupTransactionsItemsDataTable::OnRowChanging(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowChanging(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/ProcessedRepickupTransactionsItemsDataTable::OnRowDeleted(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowDeleted(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/ProcessedRepickupTransactionsItemsDataTable::OnRowDeleting(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowDeleting(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub RemoveProcessedRepickupTransactionsItemsRow(ByVal row As DataSet1.ProcessedRepickupTransactionsItemsRow)
				MyBase.Rows.Remove(row)
			End Sub

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event ProcessedRepickupTransactionsItemsRowChanged As DataSet1.ProcessedRepickupTransactionsItemsRowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event ProcessedRepickupTransactionsItemsRowChanging As DataSet1.ProcessedRepickupTransactionsItemsRowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event ProcessedRepickupTransactionsItemsRowDeleted As DataSet1.ProcessedRepickupTransactionsItemsRowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event ProcessedRepickupTransactionsItemsRowDeleting As DataSet1.ProcessedRepickupTransactionsItemsRowChangeEventHandler
		End Class

		Public Class ProcessedRepickupTransactionsItemsRow
			Inherits DataRow
			Private tableProcessedRepickupTransactionsItems As DataSet1.ProcessedRepickupTransactionsItemsDataTable

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property BarCode As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableProcessedRepickupTransactionsItems.BarCodeColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'BarCode' in table 'ProcessedRepickupTransactionsItems' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableProcessedRepickupTransactionsItems.BarCodeColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property BoxNumber As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableProcessedRepickupTransactionsItems.BoxNumberColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'BoxNumber' in table 'ProcessedRepickupTransactionsItems' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableProcessedRepickupTransactionsItems.BoxNumberColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property Description As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableProcessedRepickupTransactionsItems.DescriptionColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'Description' in table 'ProcessedRepickupTransactionsItems' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableProcessedRepickupTransactionsItems.DescriptionColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property Destruction As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableProcessedRepickupTransactionsItems.DestructionColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'Destruction' in table 'ProcessedRepickupTransactionsItems' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableProcessedRepickupTransactionsItems.DestructionColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property LocationCode As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableProcessedRepickupTransactionsItems.LocationCodeColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'LocationCode' in table 'ProcessedRepickupTransactionsItems' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableProcessedRepickupTransactionsItems.LocationCodeColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub New(ByVal rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableProcessedRepickupTransactionsItems = DirectCast(MyBase.Table, DataSet1.ProcessedRepickupTransactionsItemsDataTable)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsBarCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableProcessedRepickupTransactionsItems.BarCodeColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsBoxNumberNull() As Boolean
				Return MyBase.IsNull(Me.tableProcessedRepickupTransactionsItems.BoxNumberColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsDescriptionNull() As Boolean
				Return MyBase.IsNull(Me.tableProcessedRepickupTransactionsItems.DescriptionColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsDestructionNull() As Boolean
				Return MyBase.IsNull(Me.tableProcessedRepickupTransactionsItems.DestructionColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsLocationCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableProcessedRepickupTransactionsItems.LocationCodeColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetBarCodeNull()
				MyBase.Item(Me.tableProcessedRepickupTransactionsItems.BarCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetBoxNumberNull()
				MyBase.Item(Me.tableProcessedRepickupTransactionsItems.BoxNumberColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetDescriptionNull()
				MyBase.Item(Me.tableProcessedRepickupTransactionsItems.DescriptionColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetDestructionNull()
				MyBase.Item(Me.tableProcessedRepickupTransactionsItems.DestructionColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetLocationCodeNull()
				MyBase.Item(Me.tableProcessedRepickupTransactionsItems.LocationCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub
		End Class

		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Class ProcessedRepickupTransactionsItemsRowChangeEvent
			Inherits EventArgs
			Private eventRow As DataSet1.ProcessedRepickupTransactionsItemsRow

			Private eventAction As DataRowAction

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Row As DataSet1.ProcessedRepickupTransactionsItemsRow
				Get
					Return Me.eventRow
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub New(ByVal row As DataSet1.ProcessedRepickupTransactionsItemsRow, ByVal action As DataRowAction)
				MyBase.New()
				Me.eventRow = row
				Me.eventAction = action
			End Sub
		End Class

		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Delegate Sub ProcessedRepickupTransactionsItemsRowChangeEventHandler(ByVal sender As Object, ByVal e As DataSet1.ProcessedRepickupTransactionsItemsRowChangeEvent)

		<Serializable>
		<XmlSchemaProvider("GetTypedTableSchema")>
		Public Class SalesRevenue2DataTable
			Inherits TypedTableBase(Of DataSet1.SalesRevenue2Row)
			Private columnCompanyCode As DataColumn

			Private columnMonth As DataColumn

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property CompanyCodeColumn As DataColumn
				Get
					Return Me.columnCompanyCode
				End Get
			End Property

			<Browsable(False)>
			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Default Public ReadOnly Property Item(ByVal index As Integer) As DataSet1.SalesRevenue2Row
				Get
					Return DirectCast(MyBase.Rows(index), DataSet1.SalesRevenue2Row)
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property MonthColumn As DataColumn
				Get
					Return Me.columnMonth
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub New()
				MyBase.New()
				MyBase.TableName = "SalesRevenue2"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub New(ByVal table As DataTable)
				MyBase.New()
				MyBase.TableName = table.TableName
				If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
					MyBase.CaseSensitive = table.CaseSensitive
				End If
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Locale.ToString(), table.DataSet.Locale.ToString(), False) <> 0) Then
					MyBase.Locale = table.Locale
				End If
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.[Namespace], table.DataSet.[Namespace], False) <> 0) Then
					MyBase.[Namespace] = table.[Namespace]
				End If
				MyBase.Prefix = table.Prefix
				MyBase.MinimumCapacity = table.MinimumCapacity
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub AddSalesRevenue2Row(ByVal row As DataSet1.SalesRevenue2Row)
				MyBase.Rows.Add(row)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function AddSalesRevenue2Row(ByVal CompanyCode As String, ByVal Month As String) As DataSet1.SalesRevenue2Row
				Dim salesRevenue2Row As DataSet1.SalesRevenue2Row = DirectCast(MyBase.NewRow(), DataSet1.SalesRevenue2Row)
				salesRevenue2Row.ItemArray = New Object() { CompanyCode, Month }
				MyBase.Rows.Add(salesRevenue2Row)
				Return salesRevenue2Row
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim salesRevenue2DataTable As DataSet1.SalesRevenue2DataTable = DirectCast(MyBase.Clone(), DataSet1.SalesRevenue2DataTable)
				salesRevenue2DataTable.InitVars()
				Return salesRevenue2DataTable
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSet1.SalesRevenue2DataTable()
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSet1.SalesRevenue2Row)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Shared Function GetTypedTableSchema(ByVal xs As XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
				Dim xmlSchemaComplexType As System.Xml.Schema.XmlSchemaComplexType
				Dim xmlSchemaComplexType1 As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType()
				Dim xmlSchemaSequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence()
				Dim dataSet1 As ssiFinal.DataSet1 = New ssiFinal.DataSet1()
				Dim xmlSchemaAny As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny() With
				{
					.[Namespace] = "http://www.w3.org/2001/XMLSchema",
					.MinOccurs = New Decimal(0),
					.MaxOccurs = New Decimal(-1, -1, -1, False, 0),
					.ProcessContents = XmlSchemaContentProcessing.Lax
				}
				xmlSchemaSequence.Items.Add(xmlSchemaAny)
				Dim xmlSchemaAny1 As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny() With
				{
					.[Namespace] = "urn:schemas-microsoft-com:xml-diffgram-v1",
					.MinOccurs = New Decimal(1),
					.ProcessContents = XmlSchemaContentProcessing.Lax
				}
				xmlSchemaSequence.Items.Add(xmlSchemaAny1)
				Dim xmlSchemaAttribute As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute() With
				{
					.Name = "namespace",
					.FixedValue = dataSet1.[Namespace]
				}
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute1 As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute() With
				{
					.Name = "tableTypeName",
					.FixedValue = "SalesRevenue2DataTable"
				}
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1)
				xmlSchemaComplexType1.Particle = xmlSchemaSequence
				Dim schemaSerializable As System.Xml.Schema.XmlSchema = dataSet1.GetSchemaSerializable()
				If (xs.Contains(schemaSerializable.TargetNamespace)) Then
					Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
					Dim memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream()
					Try
						schemaSerializable.Write(memoryStream)
						Dim enumerator As IEnumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator()
						While enumerator.MoveNext()
							Dim current As System.Xml.Schema.XmlSchema = DirectCast(enumerator.Current, System.Xml.Schema.XmlSchema)
							memoryStream1.SetLength(CLng(0))
							current.Write(memoryStream1)
							If (memoryStream.Length <> memoryStream1.Length) Then
								Continue While
							End If
							memoryStream.Position = CLng(0)
							memoryStream1.Position = CLng(0)
							While memoryStream.Position <> memoryStream.Length AndAlso memoryStream.ReadByte() = memoryStream1.ReadByte()
							End While
							If (memoryStream.Position <> memoryStream.Length) Then
								Continue While
							End If
							xmlSchemaComplexType = xmlSchemaComplexType1
							Return xmlSchemaComplexType
						End While
					Finally
						If (memoryStream IsNot Nothing) Then
							memoryStream.Close()
						End If
						If (memoryStream1 IsNot Nothing) Then
							memoryStream1.Close()
						End If
					End Try
				End If
				xs.Add(schemaSerializable)
				xmlSchemaComplexType = xmlSchemaComplexType1
				Return xmlSchemaComplexType
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Private Sub InitClass()
				Me.columnCompanyCode = New DataColumn("CompanyCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCompanyCode)
				Me.columnMonth = New DataColumn("Month", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMonth)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub InitVars()
				Me.columnCompanyCode = MyBase.Columns("CompanyCode")
				Me.columnMonth = MyBase.Columns("Month")
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
				Return New DataSet1.SalesRevenue2Row(builder)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function NewSalesRevenue2Row() As DataSet1.SalesRevenue2Row
				Return DirectCast(MyBase.NewRow(), DataSet1.SalesRevenue2Row)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/SalesRevenue2DataTable::OnRowChanged(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowChanged(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/SalesRevenue2DataTable::OnRowChanging(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowChanging(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/SalesRevenue2DataTable::OnRowDeleted(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowDeleted(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/SalesRevenue2DataTable::OnRowDeleting(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowDeleting(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub RemoveSalesRevenue2Row(ByVal row As DataSet1.SalesRevenue2Row)
				MyBase.Rows.Remove(row)
			End Sub

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event SalesRevenue2RowChanged As DataSet1.SalesRevenue2RowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event SalesRevenue2RowChanging As DataSet1.SalesRevenue2RowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event SalesRevenue2RowDeleted As DataSet1.SalesRevenue2RowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event SalesRevenue2RowDeleting As DataSet1.SalesRevenue2RowChangeEventHandler
		End Class

		Public Class SalesRevenue2Row
			Inherits DataRow
			Private tableSalesRevenue2 As DataSet1.SalesRevenue2DataTable

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property CompanyCode As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableSalesRevenue2.CompanyCodeColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'CompanyCode' in table 'SalesRevenue2' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableSalesRevenue2.CompanyCodeColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property Month As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableSalesRevenue2.MonthColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'Month' in table 'SalesRevenue2' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableSalesRevenue2.MonthColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub New(ByVal rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableSalesRevenue2 = DirectCast(MyBase.Table, DataSet1.SalesRevenue2DataTable)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsCompanyCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableSalesRevenue2.CompanyCodeColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsMonthNull() As Boolean
				Return MyBase.IsNull(Me.tableSalesRevenue2.MonthColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetCompanyCodeNull()
				MyBase.Item(Me.tableSalesRevenue2.CompanyCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetMonthNull()
				MyBase.Item(Me.tableSalesRevenue2.MonthColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub
		End Class

		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Class SalesRevenue2RowChangeEvent
			Inherits EventArgs
			Private eventRow As DataSet1.SalesRevenue2Row

			Private eventAction As DataRowAction

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Row As DataSet1.SalesRevenue2Row
				Get
					Return Me.eventRow
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub New(ByVal row As DataSet1.SalesRevenue2Row, ByVal action As DataRowAction)
				MyBase.New()
				Me.eventRow = row
				Me.eventAction = action
			End Sub
		End Class

		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Delegate Sub SalesRevenue2RowChangeEventHandler(ByVal sender As Object, ByVal e As DataSet1.SalesRevenue2RowChangeEvent)

		<Serializable>
		<XmlSchemaProvider("GetTypedTableSchema")>
		Public Class SalesRevenueDataTable
			Inherits TypedTableBase(Of DataSet1.SalesRevenueRow)
			Private columnCompanyCode As DataColumn

			Private columnJanuary As DataColumn

			Private columnFebruary As DataColumn

			Private columnMarch As DataColumn

			Private columnApril As DataColumn

			Private columnMay As DataColumn

			Private columnJune As DataColumn

			Private columnJuly As DataColumn

			Private columnAugust As DataColumn

			Private columnSeptember As DataColumn

			Private columnOctober As DataColumn

			Private columnNovember As DataColumn

			Private columnDecember As DataColumn

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property AprilColumn As DataColumn
				Get
					Return Me.columnApril
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property AugustColumn As DataColumn
				Get
					Return Me.columnAugust
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property CompanyCodeColumn As DataColumn
				Get
					Return Me.columnCompanyCode
				End Get
			End Property

			<Browsable(False)>
			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property DecemberColumn As DataColumn
				Get
					Return Me.columnDecember
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property FebruaryColumn As DataColumn
				Get
					Return Me.columnFebruary
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Default Public ReadOnly Property Item(ByVal index As Integer) As DataSet1.SalesRevenueRow
				Get
					Return DirectCast(MyBase.Rows(index), DataSet1.SalesRevenueRow)
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property JanuaryColumn As DataColumn
				Get
					Return Me.columnJanuary
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property JulyColumn As DataColumn
				Get
					Return Me.columnJuly
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property JuneColumn As DataColumn
				Get
					Return Me.columnJune
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property MarchColumn As DataColumn
				Get
					Return Me.columnMarch
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property MayColumn As DataColumn
				Get
					Return Me.columnMay
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property NovemberColumn As DataColumn
				Get
					Return Me.columnNovember
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property OctoberColumn As DataColumn
				Get
					Return Me.columnOctober
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property SeptemberColumn As DataColumn
				Get
					Return Me.columnSeptember
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub New()
				MyBase.New()
				MyBase.TableName = "SalesRevenue"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub New(ByVal table As DataTable)
				MyBase.New()
				MyBase.TableName = table.TableName
				If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
					MyBase.CaseSensitive = table.CaseSensitive
				End If
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Locale.ToString(), table.DataSet.Locale.ToString(), False) <> 0) Then
					MyBase.Locale = table.Locale
				End If
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.[Namespace], table.DataSet.[Namespace], False) <> 0) Then
					MyBase.[Namespace] = table.[Namespace]
				End If
				MyBase.Prefix = table.Prefix
				MyBase.MinimumCapacity = table.MinimumCapacity
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub AddSalesRevenueRow(ByVal row As DataSet1.SalesRevenueRow)
				MyBase.Rows.Add(row)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function AddSalesRevenueRow(ByVal CompanyCode As String, ByVal January As String, ByVal February As String, ByVal March As String, ByVal April As String, ByVal May As String, ByVal June As String, ByVal July As String, ByVal August As String, ByVal September As String, ByVal October As String, ByVal November As String, ByVal December As String) As DataSet1.SalesRevenueRow
				Dim salesRevenueRow As DataSet1.SalesRevenueRow = DirectCast(MyBase.NewRow(), DataSet1.SalesRevenueRow)
				salesRevenueRow.ItemArray = New Object() { CompanyCode, January, February, March, April, May, June, July, August, September, October, November, December }
				MyBase.Rows.Add(salesRevenueRow)
				Return salesRevenueRow
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim salesRevenueDataTable As DataSet1.SalesRevenueDataTable = DirectCast(MyBase.Clone(), DataSet1.SalesRevenueDataTable)
				salesRevenueDataTable.InitVars()
				Return salesRevenueDataTable
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSet1.SalesRevenueDataTable()
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSet1.SalesRevenueRow)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Shared Function GetTypedTableSchema(ByVal xs As XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
				Dim xmlSchemaComplexType As System.Xml.Schema.XmlSchemaComplexType
				Dim xmlSchemaComplexType1 As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType()
				Dim xmlSchemaSequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence()
				Dim dataSet1 As ssiFinal.DataSet1 = New ssiFinal.DataSet1()
				Dim xmlSchemaAny As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny() With
				{
					.[Namespace] = "http://www.w3.org/2001/XMLSchema",
					.MinOccurs = New Decimal(0),
					.MaxOccurs = New Decimal(-1, -1, -1, False, 0),
					.ProcessContents = XmlSchemaContentProcessing.Lax
				}
				xmlSchemaSequence.Items.Add(xmlSchemaAny)
				Dim xmlSchemaAny1 As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny() With
				{
					.[Namespace] = "urn:schemas-microsoft-com:xml-diffgram-v1",
					.MinOccurs = New Decimal(1),
					.ProcessContents = XmlSchemaContentProcessing.Lax
				}
				xmlSchemaSequence.Items.Add(xmlSchemaAny1)
				Dim xmlSchemaAttribute As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute() With
				{
					.Name = "namespace",
					.FixedValue = dataSet1.[Namespace]
				}
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute1 As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute() With
				{
					.Name = "tableTypeName",
					.FixedValue = "SalesRevenueDataTable"
				}
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1)
				xmlSchemaComplexType1.Particle = xmlSchemaSequence
				Dim schemaSerializable As System.Xml.Schema.XmlSchema = dataSet1.GetSchemaSerializable()
				If (xs.Contains(schemaSerializable.TargetNamespace)) Then
					Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
					Dim memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream()
					Try
						schemaSerializable.Write(memoryStream)
						Dim enumerator As IEnumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator()
						While enumerator.MoveNext()
							Dim current As System.Xml.Schema.XmlSchema = DirectCast(enumerator.Current, System.Xml.Schema.XmlSchema)
							memoryStream1.SetLength(CLng(0))
							current.Write(memoryStream1)
							If (memoryStream.Length <> memoryStream1.Length) Then
								Continue While
							End If
							memoryStream.Position = CLng(0)
							memoryStream1.Position = CLng(0)
							While memoryStream.Position <> memoryStream.Length AndAlso memoryStream.ReadByte() = memoryStream1.ReadByte()
							End While
							If (memoryStream.Position <> memoryStream.Length) Then
								Continue While
							End If
							xmlSchemaComplexType = xmlSchemaComplexType1
							Return xmlSchemaComplexType
						End While
					Finally
						If (memoryStream IsNot Nothing) Then
							memoryStream.Close()
						End If
						If (memoryStream1 IsNot Nothing) Then
							memoryStream1.Close()
						End If
					End Try
				End If
				xs.Add(schemaSerializable)
				xmlSchemaComplexType = xmlSchemaComplexType1
				Return xmlSchemaComplexType
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Private Sub InitClass()
				Me.columnCompanyCode = New DataColumn("CompanyCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCompanyCode)
				Me.columnJanuary = New DataColumn("January", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnJanuary)
				Me.columnFebruary = New DataColumn("February", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnFebruary)
				Me.columnMarch = New DataColumn("March", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMarch)
				Me.columnApril = New DataColumn("April", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnApril)
				Me.columnMay = New DataColumn("May", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMay)
				Me.columnJune = New DataColumn("June", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnJune)
				Me.columnJuly = New DataColumn("July", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnJuly)
				Me.columnAugust = New DataColumn("August", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAugust)
				Me.columnSeptember = New DataColumn("September", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSeptember)
				Me.columnOctober = New DataColumn("October", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnOctober)
				Me.columnNovember = New DataColumn("November", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnNovember)
				Me.columnDecember = New DataColumn("December", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDecember)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub InitVars()
				Me.columnCompanyCode = MyBase.Columns("CompanyCode")
				Me.columnJanuary = MyBase.Columns("January")
				Me.columnFebruary = MyBase.Columns("February")
				Me.columnMarch = MyBase.Columns("March")
				Me.columnApril = MyBase.Columns("April")
				Me.columnMay = MyBase.Columns("May")
				Me.columnJune = MyBase.Columns("June")
				Me.columnJuly = MyBase.Columns("July")
				Me.columnAugust = MyBase.Columns("August")
				Me.columnSeptember = MyBase.Columns("September")
				Me.columnOctober = MyBase.Columns("October")
				Me.columnNovember = MyBase.Columns("November")
				Me.columnDecember = MyBase.Columns("December")
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
				Return New DataSet1.SalesRevenueRow(builder)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function NewSalesRevenueRow() As DataSet1.SalesRevenueRow
				Return DirectCast(MyBase.NewRow(), DataSet1.SalesRevenueRow)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/SalesRevenueDataTable::OnRowChanged(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowChanged(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/SalesRevenueDataTable::OnRowChanging(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowChanging(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/SalesRevenueDataTable::OnRowDeleted(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowDeleted(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/SalesRevenueDataTable::OnRowDeleting(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowDeleting(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub RemoveSalesRevenueRow(ByVal row As DataSet1.SalesRevenueRow)
				MyBase.Rows.Remove(row)
			End Sub

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event SalesRevenueRowChanged As DataSet1.SalesRevenueRowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event SalesRevenueRowChanging As DataSet1.SalesRevenueRowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event SalesRevenueRowDeleted As DataSet1.SalesRevenueRowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event SalesRevenueRowDeleting As DataSet1.SalesRevenueRowChangeEventHandler
		End Class

		Public Class SalesRevenueRow
			Inherits DataRow
			Private tableSalesRevenue As DataSet1.SalesRevenueDataTable

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property April As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableSalesRevenue.AprilColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'April' in table 'SalesRevenue' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableSalesRevenue.AprilColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property August As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableSalesRevenue.AugustColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'August' in table 'SalesRevenue' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableSalesRevenue.AugustColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property CompanyCode As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableSalesRevenue.CompanyCodeColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'CompanyCode' in table 'SalesRevenue' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableSalesRevenue.CompanyCodeColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property December As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableSalesRevenue.DecemberColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'December' in table 'SalesRevenue' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableSalesRevenue.DecemberColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property February As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableSalesRevenue.FebruaryColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'February' in table 'SalesRevenue' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableSalesRevenue.FebruaryColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property January As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableSalesRevenue.JanuaryColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'January' in table 'SalesRevenue' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableSalesRevenue.JanuaryColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property July As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableSalesRevenue.JulyColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'July' in table 'SalesRevenue' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableSalesRevenue.JulyColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property June As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableSalesRevenue.JuneColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'June' in table 'SalesRevenue' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableSalesRevenue.JuneColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property March As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableSalesRevenue.MarchColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'March' in table 'SalesRevenue' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableSalesRevenue.MarchColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property May As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableSalesRevenue.MayColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'May' in table 'SalesRevenue' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableSalesRevenue.MayColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property November As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableSalesRevenue.NovemberColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'November' in table 'SalesRevenue' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableSalesRevenue.NovemberColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property October As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableSalesRevenue.OctoberColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'October' in table 'SalesRevenue' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableSalesRevenue.OctoberColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property September As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableSalesRevenue.SeptemberColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'September' in table 'SalesRevenue' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableSalesRevenue.SeptemberColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub New(ByVal rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableSalesRevenue = DirectCast(MyBase.Table, DataSet1.SalesRevenueDataTable)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsAprilNull() As Boolean
				Return MyBase.IsNull(Me.tableSalesRevenue.AprilColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsAugustNull() As Boolean
				Return MyBase.IsNull(Me.tableSalesRevenue.AugustColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsCompanyCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableSalesRevenue.CompanyCodeColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsDecemberNull() As Boolean
				Return MyBase.IsNull(Me.tableSalesRevenue.DecemberColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsFebruaryNull() As Boolean
				Return MyBase.IsNull(Me.tableSalesRevenue.FebruaryColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsJanuaryNull() As Boolean
				Return MyBase.IsNull(Me.tableSalesRevenue.JanuaryColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsJulyNull() As Boolean
				Return MyBase.IsNull(Me.tableSalesRevenue.JulyColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsJuneNull() As Boolean
				Return MyBase.IsNull(Me.tableSalesRevenue.JuneColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsMarchNull() As Boolean
				Return MyBase.IsNull(Me.tableSalesRevenue.MarchColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsMayNull() As Boolean
				Return MyBase.IsNull(Me.tableSalesRevenue.MayColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsNovemberNull() As Boolean
				Return MyBase.IsNull(Me.tableSalesRevenue.NovemberColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsOctoberNull() As Boolean
				Return MyBase.IsNull(Me.tableSalesRevenue.OctoberColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsSeptemberNull() As Boolean
				Return MyBase.IsNull(Me.tableSalesRevenue.SeptemberColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetAprilNull()
				MyBase.Item(Me.tableSalesRevenue.AprilColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetAugustNull()
				MyBase.Item(Me.tableSalesRevenue.AugustColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetCompanyCodeNull()
				MyBase.Item(Me.tableSalesRevenue.CompanyCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetDecemberNull()
				MyBase.Item(Me.tableSalesRevenue.DecemberColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetFebruaryNull()
				MyBase.Item(Me.tableSalesRevenue.FebruaryColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetJanuaryNull()
				MyBase.Item(Me.tableSalesRevenue.JanuaryColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetJulyNull()
				MyBase.Item(Me.tableSalesRevenue.JulyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetJuneNull()
				MyBase.Item(Me.tableSalesRevenue.JuneColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetMarchNull()
				MyBase.Item(Me.tableSalesRevenue.MarchColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetMayNull()
				MyBase.Item(Me.tableSalesRevenue.MayColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetNovemberNull()
				MyBase.Item(Me.tableSalesRevenue.NovemberColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetOctoberNull()
				MyBase.Item(Me.tableSalesRevenue.OctoberColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetSeptemberNull()
				MyBase.Item(Me.tableSalesRevenue.SeptemberColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub
		End Class

		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Class SalesRevenueRowChangeEvent
			Inherits EventArgs
			Private eventRow As DataSet1.SalesRevenueRow

			Private eventAction As DataRowAction

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Row As DataSet1.SalesRevenueRow
				Get
					Return Me.eventRow
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub New(ByVal row As DataSet1.SalesRevenueRow, ByVal action As DataRowAction)
				MyBase.New()
				Me.eventRow = row
				Me.eventAction = action
			End Sub
		End Class

		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Delegate Sub SalesRevenueRowChangeEventHandler(ByVal sender As Object, ByVal e As DataSet1.SalesRevenueRowChangeEvent)

		<Serializable>
		<XmlSchemaProvider("GetTypedTableSchema")>
		Public Class SpaceUtilizationDataTable
			Inherits TypedTableBase(Of DataSet1.SpaceUtilizationRow)
			Private columnSpaceUtilizationMonthlyReport As DataColumn

			Private columnMonthAndYear As DataColumn

			<Browsable(False)>
			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Default Public ReadOnly Property Item(ByVal index As Integer) As DataSet1.SpaceUtilizationRow
				Get
					Return DirectCast(MyBase.Rows(index), DataSet1.SpaceUtilizationRow)
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property MonthAndYearColumn As DataColumn
				Get
					Return Me.columnMonthAndYear
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property SpaceUtilizationMonthlyReportColumn As DataColumn
				Get
					Return Me.columnSpaceUtilizationMonthlyReport
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub New()
				MyBase.New()
				MyBase.TableName = "SpaceUtilization"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub New(ByVal table As DataTable)
				MyBase.New()
				MyBase.TableName = table.TableName
				If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
					MyBase.CaseSensitive = table.CaseSensitive
				End If
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Locale.ToString(), table.DataSet.Locale.ToString(), False) <> 0) Then
					MyBase.Locale = table.Locale
				End If
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.[Namespace], table.DataSet.[Namespace], False) <> 0) Then
					MyBase.[Namespace] = table.[Namespace]
				End If
				MyBase.Prefix = table.Prefix
				MyBase.MinimumCapacity = table.MinimumCapacity
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub AddSpaceUtilizationRow(ByVal row As DataSet1.SpaceUtilizationRow)
				MyBase.Rows.Add(row)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function AddSpaceUtilizationRow(ByVal SpaceUtilizationMonthlyReport As String, ByVal MonthAndYear As String) As DataSet1.SpaceUtilizationRow
				Dim spaceUtilizationRow As DataSet1.SpaceUtilizationRow = DirectCast(MyBase.NewRow(), DataSet1.SpaceUtilizationRow)
				spaceUtilizationRow.ItemArray = New Object() { SpaceUtilizationMonthlyReport, MonthAndYear }
				MyBase.Rows.Add(spaceUtilizationRow)
				Return spaceUtilizationRow
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim spaceUtilizationDataTable As DataSet1.SpaceUtilizationDataTable = DirectCast(MyBase.Clone(), DataSet1.SpaceUtilizationDataTable)
				spaceUtilizationDataTable.InitVars()
				Return spaceUtilizationDataTable
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSet1.SpaceUtilizationDataTable()
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSet1.SpaceUtilizationRow)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Shared Function GetTypedTableSchema(ByVal xs As XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
				Dim xmlSchemaComplexType As System.Xml.Schema.XmlSchemaComplexType
				Dim xmlSchemaComplexType1 As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType()
				Dim xmlSchemaSequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence()
				Dim dataSet1 As ssiFinal.DataSet1 = New ssiFinal.DataSet1()
				Dim xmlSchemaAny As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny() With
				{
					.[Namespace] = "http://www.w3.org/2001/XMLSchema",
					.MinOccurs = New Decimal(0),
					.MaxOccurs = New Decimal(-1, -1, -1, False, 0),
					.ProcessContents = XmlSchemaContentProcessing.Lax
				}
				xmlSchemaSequence.Items.Add(xmlSchemaAny)
				Dim xmlSchemaAny1 As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny() With
				{
					.[Namespace] = "urn:schemas-microsoft-com:xml-diffgram-v1",
					.MinOccurs = New Decimal(1),
					.ProcessContents = XmlSchemaContentProcessing.Lax
				}
				xmlSchemaSequence.Items.Add(xmlSchemaAny1)
				Dim xmlSchemaAttribute As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute() With
				{
					.Name = "namespace",
					.FixedValue = dataSet1.[Namespace]
				}
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute1 As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute() With
				{
					.Name = "tableTypeName",
					.FixedValue = "SpaceUtilizationDataTable"
				}
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1)
				xmlSchemaComplexType1.Particle = xmlSchemaSequence
				Dim schemaSerializable As System.Xml.Schema.XmlSchema = dataSet1.GetSchemaSerializable()
				If (xs.Contains(schemaSerializable.TargetNamespace)) Then
					Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
					Dim memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream()
					Try
						schemaSerializable.Write(memoryStream)
						Dim enumerator As IEnumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator()
						While enumerator.MoveNext()
							Dim current As System.Xml.Schema.XmlSchema = DirectCast(enumerator.Current, System.Xml.Schema.XmlSchema)
							memoryStream1.SetLength(CLng(0))
							current.Write(memoryStream1)
							If (memoryStream.Length <> memoryStream1.Length) Then
								Continue While
							End If
							memoryStream.Position = CLng(0)
							memoryStream1.Position = CLng(0)
							While memoryStream.Position <> memoryStream.Length AndAlso memoryStream.ReadByte() = memoryStream1.ReadByte()
							End While
							If (memoryStream.Position <> memoryStream.Length) Then
								Continue While
							End If
							xmlSchemaComplexType = xmlSchemaComplexType1
							Return xmlSchemaComplexType
						End While
					Finally
						If (memoryStream IsNot Nothing) Then
							memoryStream.Close()
						End If
						If (memoryStream1 IsNot Nothing) Then
							memoryStream1.Close()
						End If
					End Try
				End If
				xs.Add(schemaSerializable)
				xmlSchemaComplexType = xmlSchemaComplexType1
				Return xmlSchemaComplexType
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Private Sub InitClass()
				Me.columnSpaceUtilizationMonthlyReport = New DataColumn("SpaceUtilizationMonthlyReport", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSpaceUtilizationMonthlyReport)
				Me.columnMonthAndYear = New DataColumn("MonthAndYear", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMonthAndYear)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub InitVars()
				Me.columnSpaceUtilizationMonthlyReport = MyBase.Columns("SpaceUtilizationMonthlyReport")
				Me.columnMonthAndYear = MyBase.Columns("MonthAndYear")
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
				Return New DataSet1.SpaceUtilizationRow(builder)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function NewSpaceUtilizationRow() As DataSet1.SpaceUtilizationRow
				Return DirectCast(MyBase.NewRow(), DataSet1.SpaceUtilizationRow)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/SpaceUtilizationDataTable::OnRowChanged(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowChanged(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/SpaceUtilizationDataTable::OnRowChanging(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowChanging(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/SpaceUtilizationDataTable::OnRowDeleted(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowDeleted(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/SpaceUtilizationDataTable::OnRowDeleting(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowDeleting(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub RemoveSpaceUtilizationRow(ByVal row As DataSet1.SpaceUtilizationRow)
				MyBase.Rows.Remove(row)
			End Sub

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event SpaceUtilizationRowChanged As DataSet1.SpaceUtilizationRowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event SpaceUtilizationRowChanging As DataSet1.SpaceUtilizationRowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event SpaceUtilizationRowDeleted As DataSet1.SpaceUtilizationRowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event SpaceUtilizationRowDeleting As DataSet1.SpaceUtilizationRowChangeEventHandler
		End Class

		Public Class SpaceUtilizationRow
			Inherits DataRow
			Private tableSpaceUtilization As DataSet1.SpaceUtilizationDataTable

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property MonthAndYear As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableSpaceUtilization.MonthAndYearColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'MonthAndYear' in table 'SpaceUtilization' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableSpaceUtilization.MonthAndYearColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property SpaceUtilizationMonthlyReport As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableSpaceUtilization.SpaceUtilizationMonthlyReportColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'SpaceUtilizationMonthlyReport' in table 'SpaceUtilization' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableSpaceUtilization.SpaceUtilizationMonthlyReportColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub New(ByVal rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableSpaceUtilization = DirectCast(MyBase.Table, DataSet1.SpaceUtilizationDataTable)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsMonthAndYearNull() As Boolean
				Return MyBase.IsNull(Me.tableSpaceUtilization.MonthAndYearColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsSpaceUtilizationMonthlyReportNull() As Boolean
				Return MyBase.IsNull(Me.tableSpaceUtilization.SpaceUtilizationMonthlyReportColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetMonthAndYearNull()
				MyBase.Item(Me.tableSpaceUtilization.MonthAndYearColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetSpaceUtilizationMonthlyReportNull()
				MyBase.Item(Me.tableSpaceUtilization.SpaceUtilizationMonthlyReportColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub
		End Class

		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Class SpaceUtilizationRowChangeEvent
			Inherits EventArgs
			Private eventRow As DataSet1.SpaceUtilizationRow

			Private eventAction As DataRowAction

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Row As DataSet1.SpaceUtilizationRow
				Get
					Return Me.eventRow
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub New(ByVal row As DataSet1.SpaceUtilizationRow, ByVal action As DataRowAction)
				MyBase.New()
				Me.eventRow = row
				Me.eventAction = action
			End Sub
		End Class

		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Delegate Sub SpaceUtilizationRowChangeEventHandler(ByVal sender As Object, ByVal e As DataSet1.SpaceUtilizationRowChangeEvent)

		<Serializable>
		<XmlSchemaProvider("GetTypedTableSchema")>
		Public Class TransactionsDataTable
			Inherits TypedTableBase(Of DataSet1.TransactionsRow)
			Private columnCompanyCode As DataColumn

			Private columnDepartmentCode As DataColumn

			Private columnContactName As DataColumn

			Private columnRequestDate As DataColumn

			Private columnStatus As DataColumn

			Private columnType As DataColumn

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property CompanyCodeColumn As DataColumn
				Get
					Return Me.columnCompanyCode
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property ContactNameColumn As DataColumn
				Get
					Return Me.columnContactName
				End Get
			End Property

			<Browsable(False)>
			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property DepartmentCodeColumn As DataColumn
				Get
					Return Me.columnDepartmentCode
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Default Public ReadOnly Property Item(ByVal index As Integer) As DataSet1.TransactionsRow
				Get
					Return DirectCast(MyBase.Rows(index), DataSet1.TransactionsRow)
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property RequestDateColumn As DataColumn
				Get
					Return Me.columnRequestDate
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property StatusColumn As DataColumn
				Get
					Return Me.columnStatus
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property TypeColumn As DataColumn
				Get
					Return Me.columnType
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub New()
				MyBase.New()
				MyBase.TableName = "Transactions"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub New(ByVal table As DataTable)
				MyBase.New()
				MyBase.TableName = table.TableName
				If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
					MyBase.CaseSensitive = table.CaseSensitive
				End If
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.Locale.ToString(), table.DataSet.Locale.ToString(), False) <> 0) Then
					MyBase.Locale = table.Locale
				End If
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.[Namespace], table.DataSet.[Namespace], False) <> 0) Then
					MyBase.[Namespace] = table.[Namespace]
				End If
				MyBase.Prefix = table.Prefix
				MyBase.MinimumCapacity = table.MinimumCapacity
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub AddTransactionsRow(ByVal row As DataSet1.TransactionsRow)
				MyBase.Rows.Add(row)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function AddTransactionsRow(ByVal CompanyCode As String, ByVal DepartmentCode As String, ByVal ContactName As String, ByVal RequestDate As String, ByVal Status As String, ByVal Type As String) As DataSet1.TransactionsRow
				Dim transactionsRow As DataSet1.TransactionsRow = DirectCast(MyBase.NewRow(), DataSet1.TransactionsRow)
				transactionsRow.ItemArray = New Object() { CompanyCode, DepartmentCode, ContactName, RequestDate, Status, Type }
				MyBase.Rows.Add(transactionsRow)
				Return transactionsRow
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim transactionsDataTable As DataSet1.TransactionsDataTable = DirectCast(MyBase.Clone(), DataSet1.TransactionsDataTable)
				transactionsDataTable.InitVars()
				Return transactionsDataTable
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSet1.TransactionsDataTable()
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSet1.TransactionsRow)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Shared Function GetTypedTableSchema(ByVal xs As XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
				Dim xmlSchemaComplexType As System.Xml.Schema.XmlSchemaComplexType
				Dim xmlSchemaComplexType1 As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType()
				Dim xmlSchemaSequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence()
				Dim dataSet1 As ssiFinal.DataSet1 = New ssiFinal.DataSet1()
				Dim xmlSchemaAny As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny() With
				{
					.[Namespace] = "http://www.w3.org/2001/XMLSchema",
					.MinOccurs = New Decimal(0),
					.MaxOccurs = New Decimal(-1, -1, -1, False, 0),
					.ProcessContents = XmlSchemaContentProcessing.Lax
				}
				xmlSchemaSequence.Items.Add(xmlSchemaAny)
				Dim xmlSchemaAny1 As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny() With
				{
					.[Namespace] = "urn:schemas-microsoft-com:xml-diffgram-v1",
					.MinOccurs = New Decimal(1),
					.ProcessContents = XmlSchemaContentProcessing.Lax
				}
				xmlSchemaSequence.Items.Add(xmlSchemaAny1)
				Dim xmlSchemaAttribute As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute() With
				{
					.Name = "namespace",
					.FixedValue = dataSet1.[Namespace]
				}
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute1 As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute() With
				{
					.Name = "tableTypeName",
					.FixedValue = "TransactionsDataTable"
				}
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1)
				xmlSchemaComplexType1.Particle = xmlSchemaSequence
				Dim schemaSerializable As System.Xml.Schema.XmlSchema = dataSet1.GetSchemaSerializable()
				If (xs.Contains(schemaSerializable.TargetNamespace)) Then
					Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
					Dim memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream()
					Try
						schemaSerializable.Write(memoryStream)
						Dim enumerator As IEnumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator()
						While enumerator.MoveNext()
							Dim current As System.Xml.Schema.XmlSchema = DirectCast(enumerator.Current, System.Xml.Schema.XmlSchema)
							memoryStream1.SetLength(CLng(0))
							current.Write(memoryStream1)
							If (memoryStream.Length <> memoryStream1.Length) Then
								Continue While
							End If
							memoryStream.Position = CLng(0)
							memoryStream1.Position = CLng(0)
							While memoryStream.Position <> memoryStream.Length AndAlso memoryStream.ReadByte() = memoryStream1.ReadByte()
							End While
							If (memoryStream.Position <> memoryStream.Length) Then
								Continue While
							End If
							xmlSchemaComplexType = xmlSchemaComplexType1
							Return xmlSchemaComplexType
						End While
					Finally
						If (memoryStream IsNot Nothing) Then
							memoryStream.Close()
						End If
						If (memoryStream1 IsNot Nothing) Then
							memoryStream1.Close()
						End If
					End Try
				End If
				xs.Add(schemaSerializable)
				xmlSchemaComplexType = xmlSchemaComplexType1
				Return xmlSchemaComplexType
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Private Sub InitClass()
				Me.columnCompanyCode = New DataColumn("CompanyCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCompanyCode)
				Me.columnDepartmentCode = New DataColumn("DepartmentCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDepartmentCode)
				Me.columnContactName = New DataColumn("ContactName", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnContactName)
				Me.columnRequestDate = New DataColumn("RequestDate", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnRequestDate)
				Me.columnStatus = New DataColumn("Status", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnStatus)
				Me.columnType = New DataColumn("Type", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnType)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub InitVars()
				Me.columnCompanyCode = MyBase.Columns("CompanyCode")
				Me.columnDepartmentCode = MyBase.Columns("DepartmentCode")
				Me.columnContactName = MyBase.Columns("ContactName")
				Me.columnRequestDate = MyBase.Columns("RequestDate")
				Me.columnStatus = MyBase.Columns("Status")
				Me.columnType = MyBase.Columns("Type")
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
				Return New DataSet1.TransactionsRow(builder)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function NewTransactionsRow() As DataSet1.TransactionsRow
				Return DirectCast(MyBase.NewRow(), DataSet1.TransactionsRow)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/TransactionsDataTable::OnRowChanged(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowChanged(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/TransactionsDataTable::OnRowChanging(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowChanging(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/TransactionsDataTable::OnRowDeleted(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowDeleted(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
				' 
				' Current member / type: System.Void ssiFinal.DataSet1/TransactionsDataTable::OnRowDeleting(System.Data.DataRowChangeEventArgs)
				' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
				' 
				' Product version: 2018.2.803.0
				' Exception in: System.Void OnRowDeleting(System.Data.DataRowChangeEventArgs)
				' 
				' Visual Basic does not support this type of event usage. Please, try using other language.
				'    at ...( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 101
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 213
				'    at ..(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 546
				'    at ...(BinaryExpression ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 96
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 141
				'    at ..(IfStatement ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 407
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 78
				'    at ..Visit(IEnumerable ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 383
				'    at ..( ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 388
				'    at ..Visit(ICodeNode ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Ast\BaseCodeVisitor.cs:line 69
				'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 25
				'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
				'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
				'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
				'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
				'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
				' 
				' mailto: JustDecompilePublicFeedback@telerik.com

			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub RemoveTransactionsRow(ByVal row As DataSet1.TransactionsRow)
				MyBase.Rows.Remove(row)
			End Sub

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event TransactionsRowChanged As DataSet1.TransactionsRowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event TransactionsRowChanging As DataSet1.TransactionsRowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event TransactionsRowDeleted As DataSet1.TransactionsRowChangeEventHandler

			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Event TransactionsRowDeleting As DataSet1.TransactionsRowChangeEventHandler
		End Class

		Public Class TransactionsRow
			Inherits DataRow
			Private tableTransactions As DataSet1.TransactionsDataTable

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property CompanyCode As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableTransactions.CompanyCodeColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'CompanyCode' in table 'Transactions' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableTransactions.CompanyCodeColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property ContactName As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableTransactions.ContactNameColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'ContactName' in table 'Transactions' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableTransactions.ContactNameColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property DepartmentCode As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableTransactions.DepartmentCodeColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'DepartmentCode' in table 'Transactions' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableTransactions.DepartmentCodeColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property RequestDate As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableTransactions.RequestDateColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'RequestDate' in table 'Transactions' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableTransactions.RequestDateColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property Status As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableTransactions.StatusColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'Status' in table 'Transactions' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableTransactions.StatusColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Property Type As String
				Get
					Dim str As String
					Try
						str = Conversions.ToString(MyBase.Item(Me.tableTransactions.TypeColumn))
					Catch invalidCastException As System.InvalidCastException
						ProjectData.SetProjectError(invalidCastException)
						Throw New StrongTypingException("The value for column 'Type' in table 'Transactions' is DBNull.", invalidCastException)
					End Try
					Return str
				End Get
				Set(ByVal value As String)
					MyBase.Item(Me.tableTransactions.TypeColumn) = value
				End Set
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Friend Sub New(ByVal rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableTransactions = DirectCast(MyBase.Table, DataSet1.TransactionsDataTable)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsCompanyCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableTransactions.CompanyCodeColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsContactNameNull() As Boolean
				Return MyBase.IsNull(Me.tableTransactions.ContactNameColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsDepartmentCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableTransactions.DepartmentCodeColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsRequestDateNull() As Boolean
				Return MyBase.IsNull(Me.tableTransactions.RequestDateColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsStatusNull() As Boolean
				Return MyBase.IsNull(Me.tableTransactions.StatusColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Function IsTypeNull() As Boolean
				Return MyBase.IsNull(Me.tableTransactions.TypeColumn)
			End Function

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetCompanyCodeNull()
				MyBase.Item(Me.tableTransactions.CompanyCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetContactNameNull()
				MyBase.Item(Me.tableTransactions.ContactNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetDepartmentCodeNull()
				MyBase.Item(Me.tableTransactions.DepartmentCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetRequestDateNull()
				MyBase.Item(Me.tableTransactions.RequestDateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetStatusNull()
				MyBase.Item(Me.tableTransactions.StatusColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub SetTypeNull()
				MyBase.Item(Me.tableTransactions.TypeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub
		End Class

		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Class TransactionsRowChangeEvent
			Inherits EventArgs
			Private eventRow As DataSet1.TransactionsRow

			Private eventAction As DataRowAction

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public ReadOnly Property Row As DataSet1.TransactionsRow
				Get
					Return Me.eventRow
				End Get
			End Property

			<DebuggerNonUserCode>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
			Public Sub New(ByVal row As DataSet1.TransactionsRow, ByVal action As DataRowAction)
				MyBase.New()
				Me.eventRow = row
				Me.eventAction = action
			End Sub
		End Class

		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")>
		Public Delegate Sub TransactionsRowChangeEventHandler(ByVal sender As Object, ByVal e As DataSet1.TransactionsRowChangeEvent)
	End Class
End Namespace