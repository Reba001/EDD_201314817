﻿
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>


<!DOCTYPE html>

<html xmlns="">
<head>
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
<title>Naval Wars</title>
<meta name="keywords" content="" />
<meta name="description" content="" />
<link href="default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #ingresodeusuario {
            width: 246px;
        }
        #ingresodecontrasenia {
            width: 244px;
        }
    </style>
</head>
<body>
<div id="menu"></div>
<div id="logo">
	<h1><a href="#">Bienvenido</a></h1>
</div>
<div id="page">
	<div id="content">
		
		
	</div>
	<!-- end content -->
	<div id="sidebar">
		<div id="search" class="boxed">
			<form id="form1" runat="server">
       
        &nbsp;
       <center>
        <asp:Label ID="UserInput" runat="server" CssClass="fuente" Text="Ingrese Usuario"></asp:Label>
        <br />
        <br />
        
        <asp:TextBox ID="TextUserInput" runat="server" CssClass="fuente"  Width="197px" OnTextChanged="TextUserInput_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="PasswordInput" runat="server" CssClass="fuente" Text="Ingrese contraseña"></asp:Label>
        <br />
        <br />
        
        <asp:TextBox ID="TextPasswordInput" runat="server" CssClass="fuente" Width="190px" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnLog" runat="server" Text="Log-In" CssClass="fuente" OnClick="btnLog_Click"></asp:Button>
       </center>
        
    </form>
				
		</div>
		
		
	</div>
	<!-- end sidebar -->
	<div style="clear: both;">&nbsp;</div>
</div>
<!-- end page -->
<div id="footer">
	<p id="legal">&copy;2007 Discovery. All Rights Reserved<br />
		Designed by <a href="http://templated.co" rel="nofollow">TEMPLATED</a></p>
	<p id="links"><a href="#">Privacy</a> | <a href="#">Terms</a> | <a href="http://validator.w3.org/check/referer" title="This page validates as XHTML 1.0 Transitional"><abbr title="eXtensible HyperText Markup Language">XHTML</abbr></a> | <a href="http://jigsaw.w3.org/css-validator/check/referer" title="This page validates as CSS"><abbr title="Cascading Style Sheets">CSS</abbr></a></p>
</div>
</body>
</html>