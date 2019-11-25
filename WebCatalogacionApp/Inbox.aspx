<%@ Page Language="C#" MasterPageFile="~/CatalogacionMain.master" AutoEventWireup="true" CodeBehind="Inbox.aspx.cs" Inherits="WebCatalogacionApp.Inbox" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-sm">
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm">
                        <asp:Label ID="lblseleccion" runat="server" CssClass="lblresutado"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm">
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm">


                        <asp:GridView ID="GridInfo" AutoPostBack="true" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="true" runat="server" OnSelectedIndexChanged="GridInfo_SelectedIndexChanged" OnDataBound="GridInfo_DataBound" OnPageIndexChanging="GridInfo_PageIndexChanging">

                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="Responder" ItemStyle-CssClass="label" />

                            </Columns>

                        </asp:GridView>



                    </div>
                    <div class="col-1">
                    </div>

                    <div class="col-sm" id="divmail" runat="server">

                        <div class="row">

                            <div class="col-sm">

                                <asp:Label ID="lblestado" runat="server" Text="Estado:"></asp:Label>

                            </div>
                            <div class="col-sm">
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-sm">
                                <asp:DropDownList ID="DrEstado" CssClass="dropdown" AutoPostBack="true" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-sm">
                            </div>
                        </div>


                        <div class="row">

                            <div class="col-sm">

                                <asp:Label ID="lblDesc" runat="server" Text="Descripcion:"></asp:Label>

                            </div>
                            <div class="col-sm">
                            </div>
                        </div>
                        <div class="row">

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

                                <asp:Label ID="lblObservacion" runat="server" Text="Observaciones:"></asp:Label>

                            </div>
                            <div class="col-sm">
                            </div>
                        </div>
                        <div class="row">

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
                                <asp:Button ID="btnEnviar" CssClass="boton" runat="server" Text="Enviar respuesta" OnClick="btnEnviar_Click" />


                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm">
                                <asp:Label ID="lblexitoso" CssClass="lblresutado" runat="server" Visible="false" Text="Solicitud creada con exito"></asp:Label>

                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridInfo" EventName="selectedIndexChanged" />

            <asp:AsyncPostBackTrigger ControlID="btnEnviar" EventName="Click" />

        </Triggers>
    </asp:UpdatePanel>



    <script src="Scripts/jquery-3.1.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
</asp:Content>
