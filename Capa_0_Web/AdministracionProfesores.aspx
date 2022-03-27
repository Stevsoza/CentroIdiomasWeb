<%@ Page Title="" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="AdministracionProfesores.aspx.cs" Inherits="Capa_0_Web.AdministracionProfesores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
    <a class="nav-link" aria-current="page" href="DatosUsuario.aspx">Principal</a>
    <a class="nav-link" href="AdministracionEstudiantes.aspx">Administración Estudiantes</a>
    <a class="nav-link active" href="AdministracionProfesores.aspx">Administración Profesores</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xl-12 col-sm mx-auto my-5">
                <h1 class="display-3">Administración de Profesores</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-xl-12 col-sm">
                <asp:GridView ID="grdProfesores" runat="server" class="table table-secondary table-bordered table-condensed table-responsive bdr" AllowPaging="true" PageSize="5" EmptyDataText="No Existen Registros debe agregar un profesor" AutoGenerateColumns="False">
                    <columns>
                        <asp:TemplateField>
                            <itemtemplate>
                                <asp:LinkButton class="btn btn-secondary" runat="server" ID="btnEliminarEst" Text="Eliminar" CommandArgument='<%# Eval("ID_PROFESOR").ToString() %>' />
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <itemtemplate>
                                <asp:LinkButton class="btn btn-secondary" runat="server" ID="btnEditarEst" Text="Editar" CommandArgument='<%# Eval("ID_PROFESOR").ToString() %>' />
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID_PROFESOR" HeaderText="Id Profesor" />
                        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                        <asp:BoundField DataField="P_APELLIDO" HeaderText="Primer Apellido" />
                        <asp:BoundField DataField="S_APELLIDO" HeaderText="Segundo Apellido" />
                        <asp:BoundField DataField="EDAD" HeaderText="Edad" />
                        <asp:BoundField DataField="TELEFONO" HeaderText="Telefóno" />
                        <asp:BoundField DataField="EMAIL" HeaderText="Email" />
                        <asp:BoundField DataField="HORA_ENTRADA" HeaderText="Hora Entrada" />
                        <asp:BoundField DataField="HORA_SALIDA" HeaderText="Hora Salida" />
                    </columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row">
            <div class="col-xl-5 p-4">
                <asp:Button ID="AgregarN" CssClass="btn btn-secondary" Text="Agregar Nuevo" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
