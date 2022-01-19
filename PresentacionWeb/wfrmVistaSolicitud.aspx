<%@ Page Title="" Language="C#" MasterPageFile="~/wfrmPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmVistaSolicitud.aspx.cs" Inherits="PresentacionWeb.wfrmVistaSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="card text-center">
            <h1 class="card-title">Gestión de solucitud</h1>
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
        <div style="display: flex; justify-content: center; align-items: center">
            <div class="container text-center card p-5  m-5" style="width: 30rem;">
                <i class="fas fa-people-arrows fs-1"></i>
                <formview>
                    <formview>
                        <div class="row p-2">
                        </div>
                        <div class="row p-2">
                            <asp:Label ID="Label2" runat="server" Text="Materia"></asp:Label>
                            <asp:TextBox ID="txtMateria" runat="server" class="form-control" Width="100%" Height="40px" AutoPostBack="True" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="row ">
                            <asp:Label ID="Label3" runat="server" Text="Docente"></asp:Label>
                            <asp:TextBox ID="txtProfe" runat="server" class="form-control" Width="100%" Height="40px" AutoPostBack="True" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="row ">
                            <asp:Label ID="Label1" runat="server" Text="Estudiante"></asp:Label>
                            <asp:TextBox ID="txtEstudiante" runat="server" class="form-control" Width="100%" Height="40px" AutoPostBack="True" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="row ">
                            <asp:Label ID="Label4" runat="server" Text="Trimestre"></asp:Label>
                            <asp:TextBox ID="txtTrimestre" runat="server" class="form-control" Width="100%" Height="40px" AutoPostBack="True" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="row ">
                            <asp:Label ID="Label5" runat="server" Text="Año"></asp:Label>
                            <asp:TextBox ID="txtAnio" runat="server" class="form-control" Width="100%" Height="40px" AutoPostBack="True" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="row ">
                            <asp:Label ID="Label6" runat="server" Text="Nota actual"></asp:Label>
                            <asp:TextBox ID="txtNotaActual" runat="server" class="form-control" Width="100%" Height="40px" AutoPostBack="True" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="row ">
                            <asp:Label ID="Label7" runat="server" Text="Nota nueva" Enabled="false">
                            </asp:Label>
                            <asp:TextBox ID="txtNotaNueva" Enabled="false" min="1" max="100" TextMode="Number" runat="server" class="form-control" Width="100%" Height="40px"></asp:TextBox>
                        </div>
                        <div class="row ">
                            <asp:Label ID="Label8" runat="server" Text="Justificación">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="1" Enabled="false" ControlToValidate="txtJusti" ErrorMessage="Debe digitar una justificacion" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ValidationGroup="1" Enabled="false" ID="txtJusti" TextMode="MultiLine" runat="server" class="form-control" Width="100%" Height="100px"></asp:TextBox>
                        </div>
                        <div class="row ">
                            <asp:Label ID="Label9" runat="server" Text="Observacion">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="1" ControlToValidate="txtObservacion" ErrorMessage="Debe digitar una observacion" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ValidationGroup="1" ID="txtObservacion" TextMode="MultiLine" runat="server" class="form-control" Width="100%" Height="100px"></asp:TextBox>
                        </div>

                        <div class="row ">
                             <asp:Label ID="Label10" runat="server" Text="Seleccione su aprobacion o rechazo" />
                            <asp:DropDownList ID="txtRevision" runat="server" class="dropdown-menu-secondary form-control" Width="100%" Height="40px" >
                                <asp:ListItem Value="0" Text="" class="dropdown-item"></asp:ListItem>
                                <asp:ListItem class="dropdown-item">Aprobar</asp:ListItem>
                                <asp:ListItem class="dropdown-item">Rechazar</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="row ">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-outline-secondary  m-1" ValidationGroup="1" OnClick="btnGuardar_Click" />
                            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-outline-secondary  m-1" />
                        </div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="1" />

            </div>


            </formview>
        </div>
    </div>

    </div>
</asp:Content>
