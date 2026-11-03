Imports System.IO

Public Class VbParser

#Region "Campi privati"

    Private ReadOnly _NodeStack As New Stack(Of VbCodeElement)

#End Region
#Region "Metodo pubblico"

    Public Function Parse(filePath As String) As VbCodeFile

        Dim codeFile As New VbCodeFile(filePath)
        _NodeStack.Clear()

        If Not File.Exists(filePath) Then
            Return codeFile
        End If

        Dim righe() As String =
            File.ReadAllLines(filePath)

        ParseLines(righe, codeFile)

        Return codeFile

    End Function

#End Region

#Region "Parser"

    Private Sub ParseLines(
        righe() As String,
        codeFile As VbCodeFile)

        For i As Integer = 0 To righe.Length - 1

            Dim linea As String =
                righe(i).Trim()

            If linea = "" Then Continue For

            ParseLine(linea, i + 1, codeFile)

        Next

    End Sub

    Private Sub ParseLine(
    linea As String,
    lineNumber As Integer,
    codeFile As VbCodeFile)

        '     If IsEndClass(linea) OrElse
        'IsEndRegion(linea)
        '
        If IsEndClass(linea) OrElse
             IsEndRegion(linea) OrElse
             IsEndMethod(linea) Then

            PopNode()

            Return

        End If

        ''Dim element As VbCodeElement =
        ''TryParseClass(linea, lineNumber

        Dim element As VbCodeElement =
    TryParseContainer(linea, lineNumber)

        ' ************  Inserimento di Region e Member , ecc. ecc  ************
        If element Is Nothing Then

            element = TryParseRegion(
        linea,
        lineNumber)

        End If

        If element Is Nothing Then

            element = TryParseMember(
        linea,
        lineNumber)

        End If

        '********** Fine Inserimento di Region e Member , ecc. ecc  ************
        If element Is Nothing Then Return


        If CurrentNode() Is Nothing Then

            codeFile.AddElement(element)

        Else

            CurrentNode().AddChild(element)

        End If

        If IsContainer(element) Then

            PushNode(element)

        End If

    End Sub

    Private Function IsContainer(
    element As VbCodeElement) As Boolean

        Select Case element.Type

            Case VbCodeElementType.NamespaceBlock,
             VbCodeElementType.ClassBlock,
             VbCodeElementType.ModuleBlock,
             VbCodeElementType.StructureBlock,
             VbCodeElementType.InterfaceBlock,
             VbCodeElementType.EnumBlock,
             VbCodeElementType.RegionBlock

                Return True

        End Select

        Return False

    End Function

    Private Function TryParseClass(
    linea As String,
    lineNumber As Integer) As VbCodeElement

        Dim testo As String = linea.Trim()

        If testo.StartsWith("'") Then Return Nothing

        Dim parole() As String =
            testo.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)

        For i As Integer = 0 To parole.Length - 2

            If String.Equals(parole(i), "Class", StringComparison.OrdinalIgnoreCase) Then

                Dim node As New VbCodeElement

                node.Type = VbCodeElementType.ClassBlock
                node.Name = parole(i + 1)
                node.StartLine = lineNumber

                Return node

            End If

        Next

        Return Nothing

    End Function
    Private Function IsEndClass(
    linea As String) As Boolean

        Return linea.Trim().Equals(
        "End Class",
        StringComparison.OrdinalIgnoreCase)

    End Function

    Private Function IsEndRegion(
    linea As String) As Boolean

        Return linea.Trim().Equals(
        "#End Region",
        StringComparison.OrdinalIgnoreCase)

    End Function

    ' Inserito per gestire la chiusura di un metodo (Sub o Function)
    Private Function IsEndMethod(
    linea As String) As Boolean

        Dim testo As String = linea.Trim()

        Return testo.Equals(
                "End Sub",
                StringComparison.OrdinalIgnoreCase) _
        OrElse testo.Equals(
                "End Function",
                StringComparison.OrdinalIgnoreCase) _
        OrElse testo.Equals(
                "End Property",
                StringComparison.OrdinalIgnoreCase)

    End Function


    '************** Fine inserimento
#End Region

#Region "Altri metodi di parsing Container"
    Private Function TryParseContainer(
    linea As String,
    lineNumber As Integer) As VbCodeElement

        Dim testo As String = linea.Trim()

        If testo.StartsWith("'") Then Return Nothing

        Dim parole() As String =
        testo.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)


        For i As Integer = 0 To parole.Length - 2

            Dim tipo As VbCodeElementType


            Select Case parole(i).ToLower()

                Case "class"
                    tipo = VbCodeElementType.ClassBlock

                Case "module"
                    tipo = VbCodeElementType.ModuleBlock

                Case "structure"
                    tipo = VbCodeElementType.StructureBlock

                Case "interface"
                    tipo = VbCodeElementType.InterfaceBlock

                Case "enum"
                    tipo = VbCodeElementType.EnumBlock

                Case "namespace"
                    tipo = VbCodeElementType.NamespaceBlock

                Case Else
                    Continue For

            End Select


            Dim node As New VbCodeElement

            node.Type = tipo
            node.Name = parole(i + 1)
            node.StartLine = lineNumber

            Return node

        Next


        Return Nothing

    End Function


#End Region

#Region "Altri metodi di parsing per Region"
    Private Function TryParseRegion(
    linea As String,
    lineNumber As Integer) As VbCodeElement

        Dim testo As String = linea.Trim()

        If Not testo.StartsWith("#Region",
                            StringComparison.OrdinalIgnoreCase) Then
            Return Nothing
        End If

        Dim nome As String = testo.Substring(7).Trim()

        If nome.StartsWith("""") AndAlso
       nome.EndsWith("""") Then

            nome = nome.Substring(1, nome.Length - 2)

        End If

        Dim node As New VbCodeElement

        node.Type = VbCodeElementType.RegionBlock
        node.Name = nome
        node.StartLine = lineNumber

        Return node

    End Function
#End Region

#Region "Altri metodi di parsing per Member"
    Private Function TryParseMember(
    linea As String,
    lineNumber As Integer) As VbCodeElement

        Dim testo As String = linea.Trim()

        If testo.StartsWith("'") Then Return Nothing

        Dim parole() As String =
        testo.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)

        For i As Integer = 0 To parole.Length - 2

            Dim tipo As VbCodeElementType

            Select Case parole(i).ToLower()

                Case "sub"

                    tipo = VbCodeElementType.Method

                Case "function"

                    tipo = VbCodeElementType.Method

                Case Else

                    Continue For

            End Select

            Dim nome As String = parole(i + 1)

            Dim p As Integer = nome.IndexOf("(")

            If p >= 0 Then
                nome = nome.Substring(0, p)
            End If

            Dim node As New VbCodeElement

            node.Type = tipo
            node.Name = nome
            node.StartLine = lineNumber

            Return node

        Next

        Return Nothing

    End Function
#End Region

#Region "Gestione Stack"

    Private Sub PushNode(node As VbCodeElement)

        If node Is Nothing Then Return

        Debug.WriteLine(
    "PUSH -> " &
    node.Type.ToString() &
    " - " &
    node.Name)

        _NodeStack.Push(node)

    End Sub


    Private Function PopNode() As VbCodeElement

        If _NodeStack.Count = 0 Then
            Debug.WriteLine("STACK VUOTO")
            Return Nothing
        End If

        Dim nodo As VbCodeElement = _NodeStack.Pop()

        Debug.WriteLine(
        "POP -> " &
        nodo.Type.ToString() &
        " - " &
        nodo.Name)

        Return nodo

    End Function

    Private Function CurrentNode() As VbCodeElement

        If _NodeStack.Count = 0 Then
            Return Nothing
        End If

        Return _NodeStack.Peek()

    End Function

#End Region
End Class