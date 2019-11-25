<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CatalogacionMain.master"  CodeBehind="Nueva_Solicitud.aspx.cs" Inherits="WebCatalogacionApp.Nueva_Solicitud" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="container-fluid">
            <div class="row">
            </div>
            <div class="row">
                <div class="col-sm">
                </div>
                <div class="col-sm">

                    <asp:Label ID="lblDesc" runat="server" Text="Descripcion:"></asp:Label>

                </div>
                <div class="col-sm">
                </div>
            </div>
            <div class="row">
                <div class="col-sm">
                </div>
                <div class="col-sm">
                    <asp:TextBox ID="txtdescrip" CssClass="textbox" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm">
                </div>
            </div>
            <div class="row">
            </div>
            <div class="row">
                <div class="col-sm">
                </div>
                <div class="col-sm">

                    <asp:Label ID="lblObservacion" runat="server" Text="Observaciones:"></asp:Label>

                </div>
                <div class="col-sm">
                </div>
            </div>
            <div class="row">
                <div class="col-sm">
                </div>
                <div class="col-sm">

                    <asp:TextBox ID="txtobserv" CssClass="textboxMuti" TextMode="MultiLine" Rows="10" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm">
                </div>
            </div>
            <div class="row">
            </div>
            <div class="row">
                <div class="col-sm">
                </div>
                <div class="col-sm">
                    <asp:Button ID="btnEnviar" CssClass="boton" runat="server" Text="Nueva Solicitud" OnClick="btnEnviar_Click" />
                   

                </div>
                <div class="col-sm">
                </div>
            </div>


              <div class="row">
                <div class="col-sm">
                </div>
                <div class="col-sm">
               
                    <asp:Label ID="lblexitoso" runat="server"  CssClass="lblresutado" Visible="false"  Text="Solicitud creada con exito"></asp:Label>
                   

                </div>
                <div class="col-sm">
                </div>
            </div>

        </div>


 


    <script src="Scripts/jquery-3.1.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
</asp:Content>