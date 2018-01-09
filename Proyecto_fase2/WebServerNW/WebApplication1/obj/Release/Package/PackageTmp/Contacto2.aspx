<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente2.Master" AutoEventWireup="true" CodeBehind="Contacto2.aspx.cs" Inherits="WebApplication1.Contacto2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div style="text-align:center; float:none; width:300px;">Ingresar Modificar y Eliminar Contacto:
             

        </div>
    <table style="width: 90%;">
        <tr>
            <td>Nickname </td>
            
            <td><asp:TextBox ID="txtNickname" runat="server"  Width="237px"></asp:TextBox></td>

            <td> <asp:Label ID="Label1" runat="server" Text=""></asp:Label> </td>
            
        </tr>
        <tr>
            
            <td>Contraseña</td>
            
            <td><asp:TextBox ID="txtContrasenia" runat="server"  Width="237px"></asp:TextBox></td>
            
            <td> <asp:Label ID="Label2" runat="server" Text=""></asp:Label> </td>
            
        </tr>
        <tr>
            
            <td>Correo Electronico</td>
            
            <td><asp:TextBox ID="txtCorreo" runat="server"  Width="237px"></asp:TextBox></td>
            
            <td> <asp:Label ID="Label3" runat="server" Text=""></asp:Label> </td>
            
        </tr>
       
        <tr>
            <td> <asp:Button ID="btnModificar" runat="server" Text="Guardar Cambios" OnClick="Button4_Click"></asp:Button> </td>
            
            <td> <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Usuario" OnClick="Button5_Click"></asp:Button> </td>
            
            <td> <asp:Button ID="btIngresar" runat="server" Text="Ingresar Usuario"  OnClick="Button6_Click"></asp:Button> </td>
            
        </tr>
    </table>
        <div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        <br/>
        <br/>
        <br/>
        <br/>

        <div id ="GeneracionGrafos_derechaE">
            &nbsp;<div style="text-align:center; float:none; width:325px;">ARBOL DE CONTACTOS</div>
        </div>

        <div id="GrafoUE">
            <div style="text-align:center; float:left; width:730px;">
                
                <asp:Image ID="Image10" runat="server" Height="700px" Width="725px" GenerateEmptyAlternateText="True" AlternateText="Imagen no disponible" />        
            </div>

        </div>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        </center>
</asp:Content>
