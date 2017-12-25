<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="IngresoUsuarios.aspx.cs" Inherits="WebApplication1.IngresoUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <table style="width: 90%;">
        <tr>
            <td>Nickname </td>
            
            <td><asp:TextBox ID="txtNickname" runat="server"  Width="237px"></asp:TextBox></td>

            
            
        </tr>
        <tr>
            
            <td>Contraseña</td>
            
            <td><asp:TextBox ID="txtContrasenia" runat="server"  Width="237px"></asp:TextBox></td>
            
            
            
        </tr>
        <tr>
            
            <td>Correo Electronico</td>
            
            <td><asp:TextBox ID="txtCorreo" runat="server"  Width="237px"></asp:TextBox></td>
            
                        
        </tr>
        
        <tr>
            <td> <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="Button4_Click"></asp:Button> </td>
            
            <td> 
            </td>
            
            
        </tr>
        <tr>
            <td>  

            </td>
            <td>
                <center> 
                    
                Buscar Archivo<br />
&nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
                    <br />
                </center> 
            </td>
            
            
        </tr>
        <tr>
            <td>  

            </td>
            <td>
                 
                <br />
                 
                <asp:Button ID="Button1" runat="server" Text="Cargar Archivo Usuarios" OnClick="Button7_Click"></asp:Button>
                 <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <br />
                <br />
            </td>
            
            
        </tr>
        

        <tr>
            <td>  


            </td>
            <td>
                 
                <br />
                 
                <asp:Button ID="Button2" runat="server" Text="Cargar Archivo Juegos" OnClick="Button8_Click"></asp:Button>
                 <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                <br />
            </td>
            
            
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
    </center>
</asp:Content>

