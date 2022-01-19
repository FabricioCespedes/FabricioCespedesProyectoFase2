<%@ Page Title="" Language="C#" MasterPageFile="~/wfrmPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmVistaInicio.aspx.cs" Inherits="PresentacionWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card text-center">
            <h1 class="card-title">Bienvenido al sistema de colegio Fabricio</h1>
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
        <div class="col justify-content-start">
            <div class="row align-items-start">
                <div class="container text-center  card  position-absolute  p-5  m-5" style="width: 30rem; top: 30%; left: 25%;">
                        <i class="fas fa-bars fs-1"> MENU </i>
                    <div class="row p-2">
                        <asp:Button CssClass="btn btn-outline-secondary m-1" ID="btnHorarios" runat="server" Text="Horarios" Visible="false" OnClick="btnHorarios_Click" />
                    </div>
                    <div class="row p-2">
                        <asp:Button CssClass="btn btn-outline-secondary m-1" ID="btnSolicitudes" runat="server" Text="Solicitudes" Visible="false" OnClick="btnSolicitudes_Click"/>
                    </div>
                    <div class="row p-2">
                        <asp:Button CssClass="btn btn-outline-secondary m-1" ID="btnCalifaciones" runat="server" Text="Califaciones" Visible="false" OnClick="btnCalifaciones_Click" />
                    </div>
                    <div class="row p-2">
                        <asp:Button CssClass="btn btn-outline-secondary m-1" ID="btnAsistencia" runat="server" Text="Asistencia" Visible="false" OnClick="btnAsistencia_Click" />
                    </div>
                    <div class="row p-2">
                        <asp:Button CssClass="btn btn-outline-secondary m-1"  ID="btnSalir" runat="server" Text="Salir"  OnClick="btnSalir_Click" />
                    </div>

                </div>
            </div>
            <asp:Image runat="server" Style="padding: 2%" ImageUrl="https://images.theconversation.com/files/270544/original/file-20190423-175514-1rng58t.jpg?ixlib=rb-1.1.0&q=45&auto=format&w=1200&h=900.0&fit=crop" BorderWidth="0px" Width="100%"></asp:Image>


        </div>
</asp:Content>
