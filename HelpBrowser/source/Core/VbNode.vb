

Public Class VbNode

    Public Property Text As String

    Public Property Kind As NodeKind

    Public Property Line As Integer

    Public Property FilePath As String

    Public Property Children As New List(Of VbNode)



    Public Enum NodeKind

        File
        ClassNode
        ModuleNode
        RegionNode
        MethodNode
        PropertyNode
        ConstructorNode
        EnumNode
        InterfaceNode

    End Enum

End Class