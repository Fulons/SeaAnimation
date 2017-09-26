Imports System.Xml

Public Class Renderable
#Region "Member variables"
    Public what As RenderObject
    Public where As Vector2
    Public animation As Animation
    Public id As Guid

    Public children As New List(Of Renderable)
#End Region

#Region "Constructors"
    Public Sub New()
        id = Guid.NewGuid()
    End Sub

    'Creates a renderable from an XmlNode
    Public Sub New(node As XmlNode)
        Load(node)
    End Sub
#End Region
#Region "Public Methods"
    'Updates all animations and children
    Public Sub Update(dt As Double)
        If animation IsNot Nothing Then
            animation.Update(dt)
            animation.UpdateRenderObject(what)
        End If
        For Each child In children
            child.Update(dt)
        Next
    End Sub

    'Renders a preview of the RenderObject into g
    Public Sub RenderPreview(ByRef g As Graphics, size As Vector2)
        what.RenderPreview(g, size)
    End Sub

    'Uses a transform stack to transform the object and its children according to the position of parent and animation transformation
    Public Sub Render(ByRef g As Graphics, ByRef transformStack As Stack(Of Matrix3x2))
        Dim m As Matrix3x2 = Matrix3x2.Identity
        If animation IsNot Nothing Then
            m = animation.GetTransformation()
        End If
        m = m * Matrix3x2.CreateTranslation(where) * transformStack.Peek()
        g.Transform = New Drawing2D.Matrix(m.M11, m.M12, m.M21, m.M22, m.M31, m.M32)
        what.Render(g)
        transformStack.Push(m)
        For Each child In children
            child.Render(g, transformStack)
        Next
        transformStack.Pop()
    End Sub

    'Restarts the animation and all childrens animation to ensure they are synced up
    Public Sub RestartAnimation()
        If animation IsNot Nothing Then
            animation.RestartAnimation()
        End If
        For Each child In children
            child.RestartAnimation()
        Next
    End Sub
#End Region
#Region "Save/Load"
    'Creates a xmlNode containing all essential member variables
    Public Function Save(doc As XmlDocument) As XmlNode
        Dim n As XmlNode = doc.CreateNode(XmlNodeType.Element, "Renderable", "")

        Dim attribute As XmlAttribute = doc.CreateAttribute("id")
        attribute.Value = Me.id.ToString
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("WhereX")
        attribute.Value = where.X
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("WhereY")
        attribute.Value = where.Y
        n.Attributes.Append(attribute)

        If animation IsNot Nothing Then
            n.AppendChild(animation.Save(doc))
        End If

        If what IsNot Nothing Then
            n.AppendChild(what.Save(doc))
        End If

        For Each child As Renderable In children
            n.AppendChild(child.Save(doc))
        Next

        Return n
    End Function

    'Loads values from a xmlNode
    Public Sub Load(node As XmlNode)
        For Each attribute As XmlAttribute In node.Attributes
            If attribute.Name = "id" Then
                Me.id = Guid.Parse(attribute.Value)
            ElseIf attribute.Name = "WhereX" Then
                Me.where.X = attribute.Value
            ElseIf attribute.Name = "WhereY" Then
                Me.where.Y = attribute.Value
            End If
        Next

        For Each element As XmlNode In node.ChildNodes
            If element.Name = "Animation" Then
                animation = Animation.LoadAnimation(element)
            ElseIf element.Name = "RenderObject" Then
                what = RenderObject.LoadRenderObject(element)
            ElseIf element.Name = "Renderable" Then
                children.Add(New Renderable(element))
            End If
        Next
    End Sub
#End Region
End Class