<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CatalogacionMain.master" CodeBehind="ProductFilter.aspx.cs" Inherits="WebCatalogacionApp.ProductFilter" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <div class="col-sm-1">
            </div>
            <div class="col-sm-1">

                <asp:Label ID="lblClase" runat="server" Text="Clase:"></asp:Label>

            </div>
            <div class="col-sm">

                <asp:DropDownList ID="DrClase" class="dropdown" CssClass="dropdown" runat="server" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="DrClase_SelectedIndexChanged">
                    <asp:ListItem Text="--Seleccionar--" Value="" />
                </asp:DropDownList>

            </div>
            <div class="col-sm-1">

                <asp:Label ID="lblModificador" runat="server" Text="Modificador:"></asp:Label>

            </div>
            <div class="col-sm">

                <asp:DropDownList ID="DrModificador" runat="server" CssClass="dropdown" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="DrModificador_SelectedIndexChanged">
                    <asp:ListItem Text="--Seleccionar--" Value="" />
                </asp:DropDownList>

            </div>

        </div>
        <div class="row">
            <div class="col-sm">
                <br />
            </div>
        </div>
        <div class="row">

            <div class="col-sm-1">
            </div>

            <div class="col-sm-1">

                <asp:Label ID="lblCaracteristica" runat="server" Text="Caracteristica:"></asp:Label>

            </div>
            <div class="col-sm">

                <asp:DropDownList ID="DrCaracteristica" CssClass="dropdown" runat="server" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="DrCaracteristica_SelectedIndexChanged">
                    <asp:ListItem Text="--Seleccionar--" Value="" />
                </asp:DropDownList>

            </div>
            <div class="col-sm-1">

                <asp:Label ID="lblDenominacion" runat="server" Text="Denominacion:"></asp:Label>

            </div>
            <div class="col-sm">

                <asp:DropDownList CssClass="dropdown" ID="DrDenominacion" AutoPostBack="true" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="DrDenominacion_SelectedIndexChanged">
                    <asp:ListItem Text="--Seleccionar--" Value="" />
                </asp:DropDownList>


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
                    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="true" runat="server" OnPageIndexChanging="GridInfo_PageIndexChanging">
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
