<%@ Page Title="" Language="C#" MasterPageFile="~/wfrmPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmProfesores.aspx.cs" Inherits="PresentacionWeb.wfrmProfesores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="card-header text-center ">
            <h1>Gestionar profesores</h1>
        </div>
                <%--Alert--%>
        <div>
            <%  if (Session["_exito"] != null)
                {%>
            <div class="alert alert-primary alert-dismissible fade show" role="alert">
                <strong><%= Session["_exito"].ToString()%> </strong>
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>

            <% Session["_exito"] = null;
                } %>

            <%if (Session["_err"] != null)
                {%>

            <div class="alert alert-danger" role="alert">
                <% = Session["_err"].ToString()%>
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>

            <%  Session["_err"] = null; 
                }%>

            <%if (Session["_wrn"] != null)
                {%>


            <div class="alert alert-warning" role="alert">
                <% = Session["_wrn"].ToString()%>
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>
            <% Session["_wrn"] = null; 
                }%>
        </div>
        <%--AlertEND--%>
        <br />    
        <div class="row mt-3">
            <div class="col-auto">
                <asp:Label ID="Label1" runat="server" Text="Nombre del profesor"></asp:Label> 
            </div>
            <div class="col-auto form-control">
                <asp:TextBox ID="txtNombreProfe" runat="server" ToolTip="Escriba aqui el texto que desea buscar" ValidationGroup="1"></asp:TextBox>  
                <asp:Button ID="btnBuscar" CssClass="btn btn-outline-secondary" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class="btn btn-outline-secondary" OnClick="btnLimpiar_Click" /> 
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-outline-secondary" />
            </div>
        </div>
           <asp:RequiredFieldValidator ID="rfvTxttitulo" runat="server" ErrorMessage="Por favor digite algun texto para buscar" ControlToValidate="txtNombreProfe" Font-Italic="True" ForeColor="#FF5050" ValidationGroup="1"></asp:RequiredFieldValidator>
        <br />
        <asp:GridView  CssClass="table table-borderedtable-striped table-hover" ID="gvProfesores" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" PageSize="5" OnPageIndexChanging="gvProfesores_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("id").ToString() %>' OnCommand="lnkEliminar_Command"><i class="far fa-trash-alt"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Actualizar">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkModificar" runat="server" OnCommand="lnkModificar_Command"><i class="fas fa-edit"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="id" HeaderText="id" Visible="False" />
                <asp:BoundField DataField="iden" HeaderText="Identificacion" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="tel" HeaderText="Telefono" />
                <asp:BoundField DataField="correo" HeaderText="Coreo" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha ingreso" />
                <asp:BoundField DataField="direccion" HeaderText="Direccion" />
                <asp:BoundField DataField="usuario" HeaderText="Usuario" />
                <asp:BoundField DataField="contrasena" HeaderText="Contreseña" />
                <asp:BoundField DataField="materia" HeaderText="Materia" />
                <asp:BoundField DataField="distrito" HeaderText="Distrito" />
                <asp:BoundField DataField="canton" HeaderText="Canton" />
                <asp:BoundField DataField="provincia" HeaderText="Provincia" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
