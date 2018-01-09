<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente2.Master" AutoEventWireup="true" CodeBehind="ClienteInicio2.aspx.cs" Inherits="WebApplication1.ClienteInicio2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="sidebar">
		
		
	<!-- end sidebar -->
	<div style="clear: both;"> 
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" Text="Hora: "></asp:Label>
                <asp:Label ID="lblHoras" runat="server" Text="Label"></asp:Label>
                <br/>
                <asp:Label ID="Label2" runat="server" Text="Minutos: "></asp:Label>
                <asp:Label ID="lblMinutos" runat="server" Text="Label"></asp:Label>
                <br/>
                <asp:Label ID="Label3" runat="server" Text="Segundos: "></asp:Label>
                <asp:Label ID="lblSegundos" runat="server" Text="Label"></asp:Label>
                <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" EnableViewState="True">
                </asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
                
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
            <td>Destino Posicion X (Letras):</td>
            
            <td>
                <br />
                <asp:TextBox ID="txtDestX" runat="server"  Width="237px"></asp:TextBox>
                <br />
            </td>

            
            
        </tr>
        <tr>
            
            <td>Destino Posicion Y (Numeros)</td>
            
            <td>
                <br />
                <asp:TextBox ID="txtDestY" runat="server"  Width="237px"></asp:TextBox>
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
                <asp:Button ID="btnMover" runat="server" Text="Mover" OnClick="Button4_Click"></asp:Button> 
                <br />
                <br />
            </td>
            
            <td> 
                <br />
                <asp:Button ID="btnAtacar" runat="server" Text="Atacar" OnClick="Button5_Click" Width="119px"></asp:Button>
                <br />
                <br />
            </td>
            
            
        </tr>
        
    </table>
        </center>

    <div id="">
        <div style="text-align:center; float:none; width:310px;">
            <asp:Button ID="btFinalizar" runat="server" Text="Finalizar Turno" OnClick="btFinalizar_Click" />

        </div>
        
    </div>

    
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
        <br/>&nbsp;<div id="contenido_derechoConsola1">

                    <div style="text-align:center; float:left; width:365px;">
                        <asp:Image ID="Image1" runat="server" Height="344px" Width="352px" />
            
                    </div>
                    <div style="float:left; text-align: center; width: 365px; ">
                        <asp:Image ID="Image2" runat="server" Height="344px" Width="352px" />
                    </div>
                    <div style="text-align:center; float:left; width:365px;">
                        <asp:Image ID="Image3" runat="server" Height="344px" Width="352px"/>
                    </div>
                    <div style="float:left; text-align: center; width: 365px; ">
                        <asp:Image ID="Image4" runat="server" Height="344px" Width="352px"/>
                    </div>
                </div>
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
</asp:Content>
