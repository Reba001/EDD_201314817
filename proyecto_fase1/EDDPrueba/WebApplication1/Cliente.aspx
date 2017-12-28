<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="WebApplication1.Cliente1" %>

<!DOCTYPE html>

<html xmlns="">
<head>
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
<title>Discovery by TEMPLATED</title>
<meta name="keywords" content="" />
<meta name="description" content="" />
<link href="default.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css"/>
    <link href='https://fonts.googleapis.com/css?family=Playfair+Display' rel='stylesheet' type='text/css'/>
</head>
<body>
    <form id="form1" runat="server">
    
    
    

<div id="logo">
	<h1><a href="#">Discovery</a></h1>
	
</div>
<div id="page">
	
	<div id="sidebar">
		
        <div style="text-align:right; float:right; width:200px;">Tiempo:
             
            <asp:Label ID="lblTiempo" runat="server" Text=""></asp:Label>

        </div>
	<!-- end sidebar -->
    </div>
    <div id="contenido_derecho">
        <div style="text-align:right; float:left; width:286px;">Nombre Usuario:
             
            <asp:Label ID="lblUser" runat="server" Text=""></asp:Label>

        </div>
        <div style="float:left; text-align: right; width: 145px; ">

            <asp:LinkButton ID="lbtLogout" runat="server" OnClick="lbtLogout_Click">Log-Out</asp:LinkButton>
        </div>
    </div>

    
    <center>
    <table style="width: 100%;">
        <tr>
            <td>Posicion X (Letras):</td>
            
            <td>
                <br />
                <asp:TextBox ID="txtPosX" runat="server"  Width="237px"></asp:TextBox>
                <br />
            </td>

            
            
        </tr>
        <tr>
            
            <td>Posicion Y (Numeros)</td>
            
            <td>
                <br />
                <asp:TextBox ID="txtPosY" runat="server"  Width="237px"></asp:TextBox>
                <br />
            </td>
            
            
            
        </tr>
        <tr>
            
            <td>Nivel</td>
            
            <td>
                <br />
                <asp:TextBox ID="txtNivel" runat="server"  Width="237px"></asp:TextBox>
                <br />
            </td>
            
                        
        </tr>
        <tr>
            
            <td>Unidad</td>
            
            <td>
                <br />
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Submarino</asp:ListItem>
                        <asp:ListItem>Bombardero</asp:ListItem>
                        <asp:ListItem>Helicóptero de combate</asp:ListItem>
                        <asp:ListItem>Fragata</asp:ListItem>
                        <asp:ListItem>Crucero</asp:ListItem>
                        <asp:ListItem>Neosatelite</asp:ListItem>
                        <asp:ListItem>Caza</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
            </td>
            
                        
        </tr>
        <tr>
            <td> 
                <br />
                <asp:Button ID="btnLimpiarTablero" runat="server" Text="Limpiar Tablero" OnClick="Button5_Click"></asp:Button> 
                <br />
                <br />
            </td>
            
            <td> 
                <br />
                <br />
                <br />
            </td>
            
            
        </tr>
        <tr>
            <td> 
                <br />
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="Button4_Click"></asp:Button> 
                <br />
                <br />
            </td>
            
            <td> 
                <br />
                <br />
                <br />
            </td>
            
            
        </tr>
        
    </table>
        </center>

    
    <div id="contenido_derechoConsola">

        <div style="text-align:right; float:left; width:300px; height: 20px;">
             
            
        </div>
        <div style="float:left; text-align: center; width: 430px; ">
            <br />
            <br />
            Consola
            <asp:TextBox ID="txtConsola" TextMode="MultiLine" Columns="60" Rows="10" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
        </div>
    </div>

    <div id="contenido_derechoConsola1">

        <div style="text-align:center; float:left; width:365px;">
            <asp:Image ID="Image1" runat="server" Height="344px" Width="352px" />
            
        </div>
        <div style="float:left; text-align: center; width: 365px; ">
            <asp:Image ID="Image2" runat="server" Height="344px" Width="352px" />
        </div>
    </div>

    <div id="contenido_derechoConsola2">

        <div style="text-align:center; float:left; width:365px;">
            <asp:Image ID="Image3" runat="server" Height="344px" Width="352px"/>
        </div>
        <div style="float:left; text-align: center; width: 365px; ">
            <asp:Image ID="Image4" runat="server" Height="344px" Width="352px"/>
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
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/><br/>
        <br/>
        <br/>
        <br/>
</div>    
   
  
<!-- end page -->
    <!--script type="text/javascript" language="javascript">  function labelUser() {


 }</script-->
    
    </form>
</body>
</html>
