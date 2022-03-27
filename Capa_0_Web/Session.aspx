<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Session.aspx.cs" Inherits="Capa_0_Web.Session" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Iniciar Sesion</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <script type="text/javascript">
        function mostrarMensaje(mensaje) {
            alert(mensaje);
        }
    </script>
    <style>
        .back {
            background-image: linear-gradient(180deg, #A9C9FF 0%, #FFBBEC 100%);
            background-attachment: fixed;
        }
    </style>
</head>
<body class="back">
    <form id="form1" class="d-flex flex-column min-vh-100" runat="server">
        <div class="container my-auto">
            <figure class="figure d-flex flex-column justify-content-center w-25 mx-auto">
                <img src="../img/idioma.png" class="figure-img img-fluid rounded" alt="..." />
                <figcaption class="visually-hidden figure-caption">A caption for the above image.</figcaption>
            </figure>

            <div class="row justify-content-center">
                <div class="col-sm-5">
                    <div class="input-group mb-3">
                        <label class="input-group-text">Usuario</label>
                        <asp:TextBox CssClass="form-control" ID="txtUsuario" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-sm-5">
                    <div class="input-group mb-3">
                        <label class="input-group-text">Contraseña</label>
                        <asp:TextBox type="password" CssClass="form-control" ID="txtContrasena" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-sm-5">
                    <div class="d-flex justify-content-center mt-5">
                        <asp:Button ID="btnOpen" CssClass="btn btn-dark mx-1" Text="Iniciar Sesion" runat="server" OnClick="btnOpen_Click" />
                        <button type="button" class="btn btn-dark mx-1" data-bs-toggle="modal" data-bs-target="#ModalLoginForm">
                            Registrarse
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <!-- Modal HTML Markup -->
            <div id="ModalLoginForm" class="modal fade">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-body m-5">
                            <h1>Registrese</h1>
                            <div role="form" method="POST" action="" runat="server">
                                <input type="hidden" name="_token" value="" />
                                <div class="form-group">
                                    <label class="control-label">Usuario</label>
                                    <div>
                                        <input id="mUsuario" runat="server" type="text" class="form-control input-lg" name="Usuario" value="" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Nombre</label>
                                    <div>
                                        <input id="mNombre" runat="server" type="text" class="form-control input-lg" name="nombre" value="" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">E-Mail</label>
                                    <div>
                                        <input id="mEmail" runat="server" type="email" class="form-control input-lg" name="Email" value="" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Primer Apellido</label>
                                    <div>
                                        <input id="mPapellido" runat="server" type="text" class="form-control input-lg" name="PrimerApellido" value="" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Segundo Apellido</label>
                                    <div>
                                        <input id="mSapellido" runat="server" type="text" class="form-control input-lg" name="SegundoApellido" value="" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Telefóno</label>
                                    <div>
                                        <input id="mTelefono" runat="server" type="text" class="form-control input-lg" name="Telefono" value="" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Edad</label>
                                    <div>
                                        <input id="mEdad" runat="server" type="text" class="form-control input-lg" name="Edad" value="" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Contraseña</label>
                                    <div>
                                        <input id="mContrasena1" runat="server" type="password" class="form-control input-lg" name="Contrasena" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Confirmar Contraseña</label>
                                    <div>
                                        <input id="mContrasena2" runat="server" type="password" class="form-control input-lg" name="Confirmar_contrasena" />
                                    </div>
                                </div>
                                <div class="form-group m-3">
                                    <div>
                                        <asp:Button runat="server" type="submit" class="btn btn-dark" Text="Enviar Registro" OnClick="Unnamed1_Click">
                                        </asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.modal -->
        </div>
    </form>
</body>
</html>
