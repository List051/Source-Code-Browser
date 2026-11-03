
Imports System.Collections.Generic

Public Class VbCodeElement

#Region "Proprietà"

    ''' <summary>
    ''' Nome dell'elemento codice
    ''' esempio: Classe, Metodo, Property
    ''' </summary>
    Public Property Name As String


    ''' <summary>
    ''' Tipo di elemento VB
    ''' </summary>
    Public Property Type As VbCodeElementType


    ''' <summary>
    ''' Riga iniziale nel file sorgente
    ''' </summary>
    Public Property StartLine As Integer


    ''' <summary>
    ''' Riga finale nel file sorgente
    ''' </summary>
    Public Property EndLine As Integer


    ''' <summary>
    ''' Nodo padre
    ''' </summary>
    Public Property Parent As VbCodeElement


    ''' <summary>
    ''' Elementi contenuti
    ''' </summary>
    Public ReadOnly Property Children As New List(Of VbCodeElement)

#End Region


#Region "Metodi"

    Public Sub AddChild(element As VbCodeElement)

        If element Is Nothing Then Return

        element.Parent = Me

        Children.Add(element)

    End Sub


    Public Function HasChildren() As Boolean

        Return Children.Count > 0

    End Function


    Public Overrides Function ToString() As String

        Return $"{Type}: {Name}"

    End Function

#End Region

End Class