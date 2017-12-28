<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="MostrarGrafo.aspx.cs" Inherits="WebApplication1.MostrarGrafo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <center>
        <div style="text-align:center; float:none; width:300px;">Piezas Sobreviviente:
             

        </div>

        <div id="grafos">
            <div style="text-align:center; float:right; width:365px;">
                
                <asp:Image ID="Image1" runat="server" Height="328px" Width="335px" />     

            </div>

            <div style="text-align:center; float:left; width:365px;">
                <asp:Image ID="Image2" runat="server" Height="328px" Width="335px" />        
            </div>

            <div style="text-align:center; float:right; width:365px;">
                
                <asp:Image ID="Image3" runat="server" Height="328px" Width="335px" />
            </div>

            <div style="text-align:center; float:left; width:365px;">
                
                <asp:Image ID="Image4" runat="server" Height="328px" Width="335px" />        
            </div>
        </div>

        <br/>
        <br/>
        <br/>
        <br/>

        <div style="text-align:center; float:none; width:300px;">Piezas Destruidas:
             

        </div>

        <div id="grafosD">
            <div style="text-align:center; float:right; width:365px;">
                
                <asp:Image ID="Image5" runat="server" Height="308px" Width="335px" />     

            </div>

            <div style="text-align:center; float:left; width:365px;">
                <asp:Image ID="Image6" runat="server" Height="310px" Width="335px" />        
            </div>

            <div style="text-align:center; float:right; width:365px;">
                
                <asp:Image ID="Image7" runat="server" Height="328px" Width="335px" />
            </div>

            <div style="text-align:center; float:left; width:365px;">
                
                <asp:Image ID="Image8" runat="server" Height="328px" Width="335px" />        
            </div>
        </div>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/><br/><br/>
        <br/><br/>
        <br/>

        <div id ="GeneracionGrafos_derecha">
            <div style="text-align:right; float:right; width:325px;">
                <asp:Button ID="Button1" runat="server" Text="Generar Grafo Usuario" OnClick="Button1_Click"></asp:Button>
            </div>
            <div style="text-align:right; float:left; width:325px;">ARBO USUARIOS

            </div>
        </div>
        

        <div id="GrafoU">
            <div style="text-align:center; float:left; width:730px;">
                
                <asp:Image ID="Image9" runat="server" Height="700px" Width="725px" />        
            </div>

        </div>


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
        </center>
</asp:Content>
