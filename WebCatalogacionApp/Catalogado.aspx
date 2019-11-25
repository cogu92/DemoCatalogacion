<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CatalogacionMain.master" CodeBehind="Catalogado.aspx.cs" Inherits="WebCatalogacionApp.Catalogado" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager runat="server" EnablePartialRendering="true"></asp:ScriptManager>

    <%--      <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>--%>
    <div class="container-fluid">



        <div class="row">
            <div class="col-sm">
            </div>
            <div class="col-sm">
                <asp:GridView ID="GridInfo" AutoPostBack="true" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="true" runat="server">
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
