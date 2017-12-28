<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="IngresoUsuarios.aspx.cs" Inherits="WebApplication1.IngresoUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <table style="width: 90%;">
        <tr>
            <td>Nickname </td>
            
            <td>
                <br />
                <asp:TextBox ID="txtNickname" runat="server"  Width="237px"></asp:TextBox>
                <br />
            </td>

            
            
        </tr>
        <tr>
            
            <td>Contraseña</td>
            
            <td>
                <br />
                <asp:TextBox ID="txtContrasenia" runat="server"  Width="237px"></asp:TextBox>
                <br />
            </td>
            
            
            
        </tr>
        <tr>
            
            <td>Correo Electronico</td>
            
            <td>
                <br />
                <asp:TextBox ID="txtCorreo" runat="server"  Width="237px"></asp:TextBox>
                <br />
            </td>
            
                        
        </tr>
        
        <tr>
            <td> <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="Button4_Click"></asp:Button> </td>
            
            <td> 
                <br />
                <asp:Button ID="btnLimpiarTablero" runat="server" Text="Limpiar Tablero" OnClick="Button20_Click"></asp:Button> 
                <br />
                <br />
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
                <br />
            </td>
            
            
        </tr>

        <tr>
            <td>  


            </td>
            <td>
                 
                <br />
                 
                <asp:Button ID="Button3" runat="server" Text="Cargar Archivo Tablero" OnClick="Button9_Click"></asp:Button>
                 <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                <br />
                <br />
            </td>
            
            
        </tr>
        <tr>
            <td>  


            </td>
            <td>
                 
                <br />
                 
                <asp:Button ID="Button4" runat="server" Text="Cargar Archivo Juego" OnClick="Button10_Click"></asp:Button>
                 <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                <br />
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

