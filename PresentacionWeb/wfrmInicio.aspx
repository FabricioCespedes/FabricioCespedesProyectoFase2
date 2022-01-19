<%@ Page Title="" Language="C#" MasterPageFile="~/wfrmPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmInicio.aspx.cs" Inherits="PresentacionWeb.wfrmInicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="card text-center">
            <h1 class="card-title">Bienvenido al sistema de colegio Fabricio</h1>
            <h6>   Claves profesor : Usuario = p1 Contrasena = p (los usuario del profe van asi p1, p2,p3 ...) </h6>
            <h6>   Claves director : Usuario = d2 Contrasena = d  </h6>
                        <h6>   Claves asistente : Usuario = a1 Contrasena = a </h6>


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
                    <i class="fa fa-user  fs-1"></i>
                    <div class="row p-2">
                        <label class="form-label">Seleccione el tipo de usuario</label>
                        <br />
                        <asp:DropDownList ID="txtTipoUsuario" runat="server" class="dropdown-menu-secondary form-control" Width="100%" Height="40px">
                            <asp:ListItem Value="0" Text="- Seleccione una opcion -"></asp:ListItem>
                            <asp:ListItem class="dropdown-item">Director</asp:ListItem>
                            <asp:ListItem class="dropdown-item">Asistente</asp:ListItem>
                            <asp:ListItem class="dropdown-item">Docente</asp:ListItem>
                        </asp:DropDownList> 
                    </div>
                    <div class="row p-2">

                        <asp:Label class=" m-1" ID="Label1" runat="server" Text="Inserte el nombre de usuario">
                            <asp:RequiredFieldValidator runat="server" ForeColor="Red" ErrorMessage="Por favor, digite el usuario" ValidationGroup="1" ControlToValidate="txtUsuario">*</asp:RequiredFieldValidator>
                        </asp:Label>
                        <asp:TextBox class="form-control m-1" ID="txtUsuario" runat="server" ValidationGroup="1"></asp:TextBox>

                    </div>
                    <div class="row p-2">
                        <asp:Label class=" m-1" ID="Label2" runat="server" Text="Inserte la contraseña">
                            <asp:RequiredFieldValidator runat="server" ForeColor="Red" ErrorMessage="Por favor, digite la contraseña " ValidationGroup="1" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
                        </asp:Label>
                        <asp:TextBox class="form-control m-1" ID="txtPassword" runat="server" ValidationGroup="1" TextMode="Password"></asp:TextBox>

                    </div>
                    <div class="row ">
                        <asp:Button ID="btnIngresar" CssClass="btn btn-outline-secondary m-1" runat="server" Text="Ingresar" ValidationGroup="1" OnClick="btnIngresar_Click" />
                    </div>
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
                </div>
            </div>
        </div>
        <asp:Image runat="server" style="padding: 2%" ImageUrl="https://images.theconversation.com/files/270544/original/file-20190423-175514-1rng58t.jpg?ixlib=rb-1.1.0&q=45&auto=format&w=1200&h=900.0&fit=crop" BorderWidth="0px" Width="100%"></asp:Image>


    </div>

</asp:Content>
