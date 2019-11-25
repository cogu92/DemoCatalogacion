<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebCatalogacionApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Web Catalogacion</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no, maximum-scale=1.0, user-scalable=0" />
    <meta name="mobile-web-app-capable" content="yes" />

    <link href="Style.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <%--<link rel="icon" type="image/jpg" href="Images/Icono.jpg" />--%>
    <%--<link rel="shortcut icon" href="Images/Icono.jpg" />--%>
    <%--<link rel="apple-touch-icon" href="Images/Icono.jpg" />--%>
    <script src="Scripts/raphael-2.1.4.min.js"></script>
    <script src="Scripts/justgage.js"></script>
    <script src="Calendar/jquery.min.js"></script>
    <style>
body, html {
  height: 100%;
  margin: 0;
}

.bg {
  /* The image used */
  background-image: url('../Images/fondoPrincipal.jpg');

  /* Full height */
  height: 100%; 

  /* Center and scale the image nicely */
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
}
.color_Font{
    color:black;
    font-weight:bold;
}
/*.carousel .item {
  height: 250px;
}*/
.carousel-inner > .item > img, .carousel-inner > .item > a > img {
    width: 100%;
    height: 300px;
}
        .navbar-brand {
            position: relative;
            background: url(Images/LogoEmpresa.jpg);
            background-size: contain;
            width: 170px;
            left: 15px;
            background-repeat:no-repeat;
        }
    
</style>
</head>
<body>
    <div id="div_arriba"></div>
    <div class="container">
        <nav class="navbar navbar-default navbar-fixed-top">
            <div class="container-fluid">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                  </button>
                    <a class="navbar-brand" href="WebHome.aspx"></a>
                    <%--<img class="navbar-brand" src="Images/LogoEmpresa.jpg" />--%>
                      <%--<asp:Image ID="ImgLogoEmp" ImageAlign="AbsMiddle" Width="70%" ImageUrl="~/Images/LogoEmpresa.jpg" runat="server" />--%>
                  <%--<a class="navbar-brand" style="color:black; font-weight:bold;" href="WebHome.aspx">User: <asp:Label ID="lblUsuario" runat="server" ForeColor="Black" Text=""></asp:Label></a>--%>
                </div>
                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class="nav navbar-nav navbar-right" id="menu_principal" runat="server">
                        <li><a href="#div_arriba" style="font-weight:bold; color:#204482;">Home</a></li>
                        <li><a href="#" onclick="foco();" style="font-weight:bold; color:#204482;">Ingreso</a></li>
                    </ul>
                </div>
            </div>
        </nav>
        <form id="form1" runat="server">
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12"><br /><br /><br /></div>
                <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12" id="home" style="text-align:center;">
                    <h1 style="color:#204482;">Sistema Catalogacion</h1>
                </div>
                <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                    <div  id="about"></div>
                    <div class="panel panel-default">
                        <div id="myCarousel" class="carousel slide" data-ride="carousel">
                        <!-- Indicators -->
                        <ol class="carousel-indicators">
                            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                            <li data-target="#myCarousel" data-slide-to="1"></li>
                            <li data-target="#myCarousel" data-slide-to="2"></li>
                        </ol>

                        <!-- Wrapper for slides -->
                        <div class="carousel-inner">
                        <div class="item active">
                            <img src="Images/fondo_1.jpg"/>
                        </div>
                        <div class="item">
                            <img src="Images/fondo_2.jpg"/>
                        </div>
                        <div class="item">
                            <img src="Images/fondo_3.jpg"/>
                        </div>
                        </div>

                        <!-- Left and right controls -->
                        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left"></span>
                        <span class="sr-only">Previous</span>
                        </a>
                        <a class="right carousel-control" href="#myCarousel" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right"></span>
                        <span class="sr-only">Next</span>
                        </a>
                    </div>
                    </div>
                    
                </div>
                <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12" id="login">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                                    <div class="alert alert-danger" runat="server" id="divError" visible="false"><asp:Label ID="lblError" runat="server" Text=""></asp:Label></div>
                                </div>
                                <div class="col-sm-5 col-md-5 col-lg-5 col-xs-6">
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-5 col-md-5 col-lg-5 col-xs-6">
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                        <asp:TextBox ID="txtClave" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-2 col-md-2 col-lg-2 col-xs-12">
                                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary btn-block" OnClick="btnIngresar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                    <br />
                </div>
            </div>
        
        </form>
        <script>
            $(document).on('click','.navbar-collapse.in',function(e) {
            if( $(e.target).is('a:not(".dropdown-toggle")') ) {
                $(this).collapse('hide');
            }
            });
        </script>
    </div>
    <script src="Scripts/jquery-3.1.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script type="text/javascript">
        sessionStorage.clear();

        function foco() {
            
            document.getElementById('txtUsuario').focus();

        }
    </script>
</body>
</html>
