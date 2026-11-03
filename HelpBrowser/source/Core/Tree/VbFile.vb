'Imports System.IO

'Public Class VbFile

'#Region "Costruttore"

'    Public Sub New()

'    End Sub


'    Public Sub New(percorso As String)

'        FullPath = percorso

'        FileName = Path.GetFileName(percorso)

'    End Sub

'#End Region


'#Region "Proprietà"

'    ''' <summary>
'    ''' Nome del file senza percorso
'    ''' </summary>
'    Public Property FileName As String


'    ''' <summary>
'    ''' Percorso completo del file
'    ''' </summary>
'    Public Property FullPath As String


'    ''' <summary>
'    ''' Nome progetto o namespace principale
'    ''' </summary>
'    Public Property NamespaceName As String


'    ''' <summary>
'    ''' Nodo radice del file
'    ''' </summary>
'    Public ReadOnly Property RootNodes As New List(Of VbNode)


'#End Region


'#Region "Metodi"


'    Public Sub AddNode(node As VbNode)

'        If node Is Nothing Then Return

'        RootNodes.Add(node)

'    End Sub



'    Public Function HasNodes() As Boolean

'        Return RootNodes.Count > 0

'    End Function



'    Public Overrides Function ToString() As String

'        Return FileName

'    End Function


'#End Region


'End Class
