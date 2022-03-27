<%@ Page Title="" EnableEventValidation="true" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="ProgramarClase.aspx.cs" Inherits="Capa_0_Web.ProgramarClase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row p-lg-3 p-sm-1 p-2">
            <div class="col-5 my-2">
                <input class="form-control" type="text" value="Clases se asignan a 2 dias posteriores como minimo" aria-label="Disabled input example" disabled readonly>
            </div>
        </div>
        <div class="row p-lg-3 p-sm-1 p-2">
            <div class="col-6">
                <div class="row">
                    <div class="col-5 rounded bg-secondary text-white text-center mx-1 p-2">
                        <label class="form-control bg-secondary text-white">Día Seleccionado</label>
                    </div>
                    <div class="col-6 rounded bg-secondary text-white text-center mx-1 p-2">
                        <asp:Label class="form-control" runat="server" ID="lbl_dia" Text="---------"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-6">
                <div class="row">
                    <div class="col-5 rounded bg-secondary text-white text-center mx-1 p-2">
                        <label class="form-control bg-secondary text-white">Hora seleccionada</label>
                    </div>
                    <div class="col-6 rounded bg-secondary text-white text-center mx-1 p-2">
                        <asp:Label class="form-control" runat="server" ID="lbl_hora" Text="---------"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="row p-lg-3 p-sm-1 p-2">
            <div class="col-3 my-2">
                <input runat="server" class="form-control" id="eldia" type="date" placeholder="Seleccione fecha" />
            </div>
            <div class="col-3 my-2">
                <asp:DropDownList CssClass="form-control" runat="server" ID="horas" AutoPostBack="false">
                    <asp:ListItem Value="08:00">08:00:am</asp:ListItem>
                    <asp:ListItem Value="09:00">09:00:am</asp:ListItem>
                    <asp:ListItem Value="10:00">10:00:am</asp:ListItem>
                    <asp:ListItem Value="11:00">11:00:am</asp:ListItem>
                    <asp:ListItem Value="12:00">12:00:pm</asp:ListItem>
                    <asp:ListItem Value="13:00">01:00:pm</asp:ListItem>
                    <asp:ListItem Value="14:00">02:00:pm</asp:ListItem>
                    <asp:ListItem Value="15:00">03:00:pm</asp:ListItem>
                    <asp:ListItem Value="16:00">04:00:pm</asp:ListItem>
                    <asp:ListItem Value="17:00">05:00:pm</asp:ListItem>
                    <asp:ListItem Value="18:00">06:00:pm</asp:ListItem>
                    <asp:ListItem Value="19:00">07:00:pm</asp:ListItem>
                    <asp:ListItem Value="20:00">08:00:pm</asp:ListItem>
                    <asp:ListItem Value="21:00">09:00:pm</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-3 text-white mx-1 p-2">
                <asp:Button runat="server" class="btn btn-secondary" Text="Enviar" ID="enviar" OnClick="enviar_Click" />
            </div>
        </div>
        <div class="row p-lg-3 p-sm-1 p-2">
            <div class="col-xl-12 my-2 col-lg-6" style="min-height:400px;">
                <asp:GridView ID="grdProfesores" class="table table-secondary table-bordered table-condensed table-responsive bdr p-sm-0 m-sm-0" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" EmptyDataText="No hay profesores disponibles en este horario">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton class="btn btn-secondary" ID="btnProgramarClase" runat="server" Text="ProgramarClase" CommandArgument='<%# Eval("ID_PROFESOR").ToString() %>' OnCommand="btnProgramarClase_Command" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID_PROFESOR" HeaderText="Id Profesor" />
                        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre Profesor" />
                        <asp:BoundField DataField="P_APELLIDO" HeaderText="Primer apellido" />
                        <asp:BoundField DataField="TELEFONO" HeaderText="Telefono" />
                        <asp:BoundField DataField="EMAIL" HeaderText="Email" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row p-lg-3 p-sm-1 p-2">
            <div class="col-xl-12 my-2 col-lg-6">
                <div class="row">
                    <div class="col d-flex justify-content-end w-25">
                        <asp:Button runat="server" ID="btnSalir" Text="Salir" class="btn btn-secondary px-5" OnClick="btnSalir_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
