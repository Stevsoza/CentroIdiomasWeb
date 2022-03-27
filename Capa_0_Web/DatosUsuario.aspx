<%@ Page Title="" EnableEventValidation="true" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="DatosUsuario.aspx.cs" Inherits="Capa_0_Web.DatosUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
    <a class="nav-link active" aria-current="page" href="DatosUsuario.aspx">Principal</a>
    <a class="nav-link" href="AdministracionEstudiantes.aspx">Administración Estudiantes</a>
    <a class="nav-link" href="AdministracionProfesores.aspx">Administración Profesores</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5 rounded-3 shadow bg-light">
        <div class="row p-lg-5 p-sm-3 p-2">
            <div class="col-sm my-2">
                <asp:Label runat="server" ID="lblId" class="form-control p-3 text-center">ID</asp:Label>
            </div>
            <div class="col-sm my-2">
                <asp:Label runat="server" ID="lblMatriculados" class="form-control p-3 text-center">Cursos matriculados</asp:Label>
            </div>
            <div class="col-sm my-2">
                <asp:Label runat="server" ID="lblNombre" class="form-control p-3 text-center">Nombre</asp:Label>
            </div>
        </div>
    </div>
    <div class="container p-3 rounded-3 shadow bg-light mb-5">
        <div class="row m-lg-5">
            <ul class="nav nav-tabs" id="myTab" role="tablist">
                <li class="nav-item" role="presentation">
                    <button class="nav-link" id="DatosUsuario-tab" data-bs-toggle="tab" data-bs-target="#DatosUsuario" type="button" role="tab" aria-controls="DatosUsuario" aria-selected="false">Datos Usuario</button>
                </li>
                <li class="nav-item" role="presentation">
                    <button class="nav-link" id="CursosEstudiante-tab" data-bs-toggle="tab" data-bs-target="#CursosEstudiante" type="button" role="tab" aria-controls="CursosEstudiante" aria-selected="false">Cursos Estudiante</button>
                </li>
                <li class="nav-item" role="presentation">
                    <button class="nav-link active" id="MatricularCurso-tab" data-bs-toggle="tab" data-bs-target="#MatricularCurso" type="button" role="tab" aria-controls="MatricularCurso" aria-selected="true">Matricular Curso</button>
                </li>
                <li class="nav-item" role="presentation">
                    <button class="nav-link" id="Clases-tab" data-bs-toggle="tab" data-bs-target="#Clases" type="button" role="tab" aria-controls="Clases" aria-selected="false">Clases</button>
                </li>
            </ul>
            <div class="tab-content" id="myTabContent">
                <div class="tab-pane fade" id="DatosUsuario" role="tabpanel" aria-labelledby="DatosUsuario-tab">
                    <div class="row m-5">
                        <div class="col-md">
                            <div class="p-2">
                                <label for="txtNombre" class="form-label">Nombre:</label>
                                <asp:Label ID="label_nom" class="form-control" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="p-2">
                                <label for="txtPrimerApe" class="form-label">Primer apellido:</label>
                                <asp:Label ID="label_ape" class="form-control" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="p-2">
                                <label for="txtSegundoApe" class="form-label">Segundo apellido:</label>
                                <asp:Label ID="label_seg" class="form-control" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row m-5">
                        <div class="col-md">
                            <div class="p-2">
                                <label for="txtEdad" class="form-label">Edad:</label>
                                <asp:Label ID="label_edad" class="form-control" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="p-2">
                                <label for="txtEmail" class="form-label">Email:</label>
                                <asp:Label ID="label_email" class="form-control" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md">
                            <div class="p-2">
                                <label for="txtTelefono" class="form-label">Telefóno:</label>
                                <asp:Label ID="label_tel" class="form-control" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="tab-pane fade" id="CursosEstudiante" role="tabpanel" aria-labelledby="CursosEstudiante-tab">
                    <div class="row m-lg-5 mx-sm-0 my-sm-3">
                        <div class="col-lg-12 col-md">
                            <div class="row">
                                <asp:GridView ID="grdCursos" class="table table-secondary table-bordered table-condensed table-responsive bdr p-sm-0 m-sm-0" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton class="btn btn-secondary" ID="btnProgramarClase" runat="server" Text="ProgramarClase" CommandArgument='<%# Eval("ID_CURSO").ToString() %>' OnCommand="btnProgramarClase_Command" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ID_CURSO" HeaderText="Id curso" />
                                        <asp:BoundField DataField="NOMBRE_CURSO" HeaderText="Nombre curso" />
                                        <asp:BoundField DataField="FECHA_INICIO" HeaderText="Fecha Inicio" />
                                        <asp:BoundField DataField="FECHA_FINAL" HeaderText="Fecha final" />
                                        <asp:BoundField DataField="HORAS_SINC_RES" HeaderText="Horas Sincronicas" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="tab-pane fade barr show active" id="MatricularCurso" role="tabpanel" aria-labelledby="MatricularCurso-tab">
                    <div class="row m-lg-5 mx-sm-0 my-sm-3">
                        <div class="col-xl-6 col-md-12 mx-auto">
                            <div class="row my-4">
                                <div class="col text-center">
                                    <p>Seleccione Programa</p>
                                </div>
                                <div class="col">
                                    <asp:DropDownList ID="Programa" runat="server" class="btn btn-outline-secondary" OnSelectedIndexChanged="Programa_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem>PROGRAMA</asp:ListItem>
                                        <asp:ListItem>Ingles</asp:ListItem>
                                        <asp:ListItem>Frances</asp:ListItem>
                                        <asp:ListItem>Aleman</asp:ListItem>
                                        <asp:ListItem>Mandarin</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row my-4">
                                <div class="col bg-secondary rounded px-0" style="min-height: 100px">
                                    <div class="card-header bg-gradient text-white">Curso a Matricular</div>
                                    <asp:GridView ID="grdCurso_d" class="table table-secondary table-bordered table-condensed table-responsive bdr m-0 px-3" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="1" EmptyDataText="No hay datos" ShowHeaderWhenEmpty="True">
                                        <Columns>
                                            <asp:BoundField DataField="NOMBRE_CURSO" HeaderText="Nombre Curso" />
                                            <asp:BoundField DataField="HORAS" HeaderText="Horas" />
                                            <asp:BoundField DataField="COSTO" HeaderText="Costo" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div>
                                </div>
                            </div>
                            <div class="row my-4">
                                <div class="col text-center">
                                    <p>Seleccione Intensidad</p>
                                </div>
                                <div class="col">
                                    <asp:DropDownList ID="Intensidad" runat="server" class="btn btn-outline-secondary" Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="Intensidad_SelectedIndexChanged">
                                        <asp:ListItem>INTENSIDAD</asp:ListItem>
                                        <asp:ListItem>BAJO</asp:ListItem>
                                        <asp:ListItem>MEDIO</asp:ListItem>
                                        <asp:ListItem>ALTO</asp:ListItem>
                                        <asp:ListItem>INTENSIVO</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row my-4">
                                <div class="col text-center">
                                    <p>Si matricula hoy la fecha de finalización sería:</p>
                                </div>
                            </div>
                            <div class="row my-4">
                                <div class="col">
                                    <asp:Label runat="server" ID="lblFecha" class="form-control text-center">fecha</asp:Label>
                                </div>
                            </div>
                            <div class="row my-4">
                                <div class="col d-flex flex-column">
                                    <asp:Button runat="server" ID="btnMatricular" Text="Matricular" class="btn btn-secondary mx-auto" Enabled="False" OnClick="btnMatricular_Click"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row my-4 mt-4">
                        <div class="col d-flex justify-content-end">
                            <asp:Button runat="server" ID="btnDeudas" Text="Pagar Deudas" class="btn btn-secondary mx-auto" Enabled="False" OnClick="btnDeudas_Click"></asp:Button>
                        </div>
                    </div>
                </div>
                <div class="tab-pane fade" id="Clases" role="tabpanel" aria-labelledby="Clases-tab">
                    <div class="row m-lg-5 m-sm-1">
                        <div class="col-lg-12 col-md">
                            <asp:GridView ID="grdClases" runat="server" class="table table-secondary table-bordered table-condensed table-responsive bdr" AllowPaging="true" PageSize="5" EmptyDataText="No Existen Registros debe crear una Clase" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton class="btn btn-secondary" runat="server" ID="btnEliminarClase" Text="Cancelar" CommandArgument='<%# Eval("ID_CLASE").ToString() %>' OnCommand="btnEliminarClase_Command" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ID_CLASE" HeaderText="Id Clase" />
                                    <asp:BoundField DataField="ID_CURSO" HeaderText="Id Curso" />
                                    <asp:BoundField DataField="ID_PROFESOR" HeaderText="Id Profesor" />
                                    <asp:BoundField DataField="NOMBRE_CURSO" HeaderText="Nombre Curso" />
                                    <asp:BoundField DataField="INICIO" HeaderText="Inicio" />
                                    <asp:BoundField DataField="FINAL" HeaderText="Final" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
