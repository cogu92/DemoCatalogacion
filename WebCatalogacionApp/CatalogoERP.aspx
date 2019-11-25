<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CatalogacionMain.master"   CodeBehind="CatalogoERP.aspx.cs" Inherits="WebCatalogacionApp.CatalogoERP" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:ScriptManager runat="server" EnablePartialRendering="true"></asp:ScriptManager>

  <%--      <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>--%>
                <div class="container-fluid">



                    <div class="row">
                        <div class="col-sm">
                            <br />
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-sm-2">
                        </div>
                        <div class="col-sm-2">
                        </div><div class="col-sm-3">

                            <asp:Label ID="lblbuscar" runat="server" Text="Buscar por Codigo o Nombre:"></asp:Label>

                        </div>
                        <div class="col-sm">

                         
                                
                        </div>
                        <div class="col-sm-1">

                           

                        </div>
                        <div class="col-sm">

                        </div>

                    </div>
                    <div class="row">
                        <div class="col-sm-2">
                        </div>
                        <div class="col-sm-2">
                        </div><div class="col-sm-2">

                          <asp:TextBox ID="txtbuscar" AutoPostBack="true" CssClass="textbox" runat="server" OnTextChanged="txtbuscar_TextChanged"></asp:TextBox>

                        </div>
                        <div class="col-sm">

                                
                        </div>
                        <div class="col-sm-1">

                           

                        </div>
                        <div class="col-sm">

                        </div>

                    </div>
                 
                    <div class="row">
                        <div class="col-sm">
                            <br />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-2">
                        </div>
                        <div class="col-sm-2">
                        </div>
                        <div class="col-sm">
                            <asp:Button ID="BtnSolicitud" CssClass="boton" runat="server" Text="Crear Solicitud" OnClick="BtnSolicitud_Click" />
                        </div>
                        <div class="col-sm">
                        </div>

                        <div class="col-sm">
                        </div>
                        <div class="col-sm">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm">
                            <br />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm">
                        </div>
                        <div class="col-sm">
                            <asp:GridView ID="GridInfo" AutoPostBack="true" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True"  AutoGenerateColumns="true" runat="server" OnPageIndexChanging="GridInfo_PageIndexChanging" >
                            </asp:GridView>

                        </div>
                        <div class="col-sm">
                        </div>
                    </div>

                </div>
   <%--         </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BtnSolicitud" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>--%>

    <script src="Scripts/jquery-3.1.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
</asp:Content>