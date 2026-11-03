Imports System.IO
Imports System.Collections.Generic

Public Class VbCodeFile

#Region "Costruttore"

    Public Sub New()

    End Sub


    Public Sub New(percorso As String)

        FullPath = percorso

        FileName = Path.GetFileName(percorso)

    End Sub

#End Region


#Region "Proprietà"

    ''' <summary>
    ''' Nome del file senza percorso
    ''' </summary>
    Public Property FileName As String


    ''' <summary>
    ''' Percorso completo del file
    ''' </summary>
    Public Property FullPath As String


    ''' <summary>
    ''' Namespace principale trovato nel file
    ''' </summary>
    Public Property NamespaceName As String


    ''' <summary>
    ''' Elementi principali del file
    ''' Classi, Moduli, Interface, Enum...
    ''' </summary>
    Public ReadOnly Property RootElements As New List(Of VbCodeElement)

#End Region


#Region "Metodi"

    Public Sub AddElement(element As VbCodeElement)

        If element Is Nothing Then Return

        RootElements.Add(element)

    End Sub



    Public Function HasElements() As Boolean

        Return RootElements.Count > 0

    End Function



    Public Overrides Function ToString() As String

        Return FileName

    End Function

#End Region


End Class