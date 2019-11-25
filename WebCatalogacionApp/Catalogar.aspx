<%@ Page Language="C#" MasterPageFile="~/CatalogacionMain.master" AutoEventWireup="true" CodeBehind="Catalogar.aspx.cs" Inherits="WebCatalogacionApp.Catalogar" %>

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
            </div>
            <div class="col-sm">

                <asp:Button ID="btnCatalogar" CssClass="boton" runat="server" Text="Catalogar" OnClick="btnCatalogar_Click" />

            </div>
            <div class="col-sm-1">
            </div>
            <div class="col-sm">
            </div>

        </div>


        <div class="row">
            <div class="col-sm">
            </div>
            <div class="col-sm12">
                <asp:Label ID="lblcalaogado_Es" CssClass="lblresutado" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblcalaogado_En" CssClass="lblresutado" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblnombrecorto" CssClass="lblresutado" runat="server"></asp:Label>
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
                <asp:GridView ID="GridInfoEs" AutoPostBack="true" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="true" runat="server">
                </asp:GridView>

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
                <asp:GridView ID="GridInfoEn" AutoPostBack="true" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="true" runat="server">
                </asp:GridView>

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
                <asp:GridView ID="GridCaracteristicas" AutoPostBack="true" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="true" AutoGenerateColumns="false" runat="server" OnRowDataBound="GridCaracteristicas_RowDataBound">
                    <Columns>
                        <asp:BoundField HeaderText="Caracteristicas" Visible="false" DataField="Id_Caracteristica" />
                        <asp:BoundField HeaderText="Caracteristicas" DataField="Nom_Caracteristica_es" />

                        <asp:TemplateField HeaderText="Descripcion">
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList1" CssClass="dropdown" runat="server">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
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
