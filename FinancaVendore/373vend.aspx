<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="373vend.aspx.cs" Inherits="FinancaVendore.data._373vend" %>

<!DOCTYPE html>

<html >

    <head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>financavendore.al</title>
	<!-- core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/font-awesome.min.css" rel="stylesheet">
    <link href="css/animate.min.css" rel="stylesheet">
    <link href="css/owl.carousel.css" rel="stylesheet">
    <link href="css/owl.transitions.css" rel="stylesheet">
    <link href="css/prettyPhoto.css" rel="stylesheet">
    <link href="css/main.css" rel="stylesheet">
    <link href="css/responsive.css" rel="stylesheet">
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
    <script src="js/respond.min.js"></script>
    <![endif]-->       
    <link rel="shortcut icon" href="images/ico/favicon.ico">
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="images/ico/apple-touch-icon-144-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="images/ico/apple-touch-icon-114-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="images/ico/apple-touch-icon-72-precomposed.png">
    <link rel="apple-touch-icon-precomposed" href="images/ico/apple-touch-icon-57-precomposed.png">
    
</head><!--/head-->

<body id="" class="homepage">
    <form id="form1" runat="server">
    <header id="top-header" class="navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <!-- responsive nav button -->
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <!-- /responsive nav button -->
                    
                    <!-- logo -->
                    <div class="navbar-brand">
                        <a class="smooth-scroll" data-section="#home" href="#home" >
                           <span>www.financavendore.al</span>
                        </a>
                    </div>
                    <!-- /logo -->
                </div>

                <!-- main nav -->
                <nav class="collapse navbar-collapse navbar-right" role="navigation">
                    <div class="main-menu">
                        <ul id="nav" class="nav navbar-nav navbar-right">
                            <li class="scroll"><a href="#home" data-section="#home">Home</a></li>
                            <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><span>Te rejat</span></a>
<ul class="dropdown-menu leftauto">
<li><a href="icons.html"> Njoftime </a></li>
<li><a href="typography.html">Artikuj</a></li>
<li><a href="buttons.html">Publikime</a></li>
</ul>
</li>
                            <li class="scroll"><a href="#about" data-section="#about">Platforma</a></li>
                            <li class="scroll"><a href="#" data-section="#services">Banka e të dhënave</a></li>
                            <li class="scroll"><a href="#portfolio" data-section="#">Si ta përdor platformën?</a></li>
                            <li class="scroll"><a href="#contact-area" data-section="#contact-area">Kontakt</a></li>   
                        </ul>
                    </div>
                </nav>
                <!-- /main nav -->
                
            </div>
        </header>
<section id="mainkategori">
    <div class="container">
        
        <div class="row">
  <div class="col-lg-12 title"><h2>Krahaso sipas 373 NJSQV-ve</h2></div></div></div>
  <div class="row"><div class="col-lg-12"><div class="col-lg-5"></div>
      <div class="col-lg-5 pull-right">
                 <div class="col-sm-6 grafikateg">
            <h3>Gjeneroni grafikun duke fiksuar: </h3></div>
<div class="col-sm-6 linqet">            
  <a href="373ind.aspx" class="btn btn-primary btn-white">Indikatorin</a>
    <a href="373vit.aspx" class="btn btn-primary btn-white">Vitin</a>
    <a href="#" class="btn btn-primary btn-white">Zonen</a>
  </div>
</div>
  </div>
            </div>
        
        </section>
     
             <section id="cta2" class="filtrim">
        <div class="container">
                 <div class="col-sm-6">
<div class="col-sm-6">
            <h4>Zgjidh Regjionin</h4>
    </div>
                     <div class="col-sm-6">
<div class="dropdown">            
    <asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="True"></asp:DropDownList>
    </div>
</div>
                     </div>
           
                <div class="col-sm-6">
                    <div class="col-sm-5">
            <h4>Njesite Vendore</h4>
                        </div>
                    <div class="col-sm-7">
<div class="indikatoret">            
    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True"></asp:DropDownList>
    </div>
</div>
                </div>
 </div>

                
    </section>
<section id="services" >
     <div class="section-header">
         <h2 class="section-title text-center wow fadeInDown"></h2></div>
                <div class="container">
                    <div class="col-lg-5 selectdata">
                            <h4>Grupet e Indikatoreve</h4>
                          <div class="regjionet">
                              <asp:DropDownList ID="dropRegjione" runat="server" AutoPostBack="True"></asp:DropDownList>
                              </div>
                        <h5>Indikatoret</h5>
                            <div class="indicatoret">
                               <asp:CheckBoxList ID="chkIndikatoret" runat="server">
                                   <asp:ListItem>item1</asp:ListItem>
                                   <asp:ListItem>item2</asp:ListItem>
                                   <asp:ListItem>item3</asp:ListItem>
                                   <asp:ListItem>item4</asp:ListItem>
                               </asp:CheckBoxList>
                            </div>
                          
                        
                             <h5>Vitet</h5>
                             <div class="vitet">
                                    
                                     <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                                   <asp:ListItem>item1</asp:ListItem>
                                   <asp:ListItem>item2</asp:ListItem>
                                   <asp:ListItem>item3</asp:ListItem>
                                   <asp:ListItem>item4</asp:ListItem>
                               </asp:CheckBoxList>
                                   </div>
                           
                            
                            
                            <div class="col-lg-12 gjenero">
                    <asp:Button ID="Button1" runat="server" Text="Gjenero Grafikun" class="btn btn-primary btn-lg btn-send-msg" /></div>
                        </div>
                <div id="grafiku" runat="server" class="col-lg-7 graphgjeneruar">
                  
                </div>


          
       
    </section><!--/#services-->

    
    <section id="testimonial">
        <div class="container">
            <div class="row">
                <div class="col-sm-8 col-sm-offset-2">

                <div id="carousel-testimonial" class="carousel slide text-center" data-ride="carousel">
                        <!-- Wrapper for slides -->
                        <div class="carousel-inner" role="listbox">
                            <div class="item active">
                                
                                <h4>Pyetje te Shpejta</h4>
                                <small>Pyetja</small>
                                <p>Pergjigjia: Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut et dolore magna aliqua. Ut enim ad minim veniam</p>
                            </div>
                            <div class="item">
                                
                                <h4>Pyetje te Shpejta</h4>
                                <small>Pyetja</small>
                                <p>Pergjigjia: Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut et dolore magna aliqua. Ut enim ad minim veniam</p>
                            </div>
                        </div>

                        <!-- Controls -->
                        <div class="btns">
                            <a class="btn btn-primary btn-sm" href="#carousel-testimonial" role="button" data-slide="prev">
                                <span class="fa fa-angle-left" aria-hidden="true"></span>
                                <span class="sr-only">Previous</span>
                            </a>
                            <a class="btn btn-primary btn-sm" href="#carousel-testimonial" role="button" data-slide="next">
                                <span class="fa fa-angle-right" aria-hidden="true"></span>
                                <span class="sr-only">Next</span>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section><!--/#testimonial-->






    <footer id="footer">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <p class="text-center">
                        &copy; 2015 <a href="www.financavendore.al">www.financavendore.al</a>
                    </p>
                    
                    <ul class="social-icons text-center">
                        <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                        <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                        <li><a href="#"><i class="fa fa-google-plus"></i></a></li>
                        <li><a href="#"><i class="fa fa-pinterest"></i></a></li>
                        <li><a href="#"><i class="fa fa-dribbble"></i></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </footer><!--/#footer-->

    <script src="js/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script src="js/mousescroll.js"></script>
    <script src="js/jquery.prettyPhoto.js"></script>
    <script src="js/jquery.isotope.min.js"></script>
    <script src="js/jquery.inview.min.js"></script>
    <script src="js/wow.min.js"></script>
    <script src="js/main.js"></script>
        </form>
</body>
</html>