<%@ Page Title="" Language="C#" MasterPageFile="~/wfrmPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmHorario.aspx.cs" Inherits="PresentacionWeb.wfrmHorario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card text-center">
            <h1 class="card-title">Gestión de horarios</h1>
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

            <% }%>

            <%if (Session["_wrn"] != null)
                {%>
            <div class="alert alert-warning" role="alert">
                <% = Session["_wrn"].ToString()%>
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>
            <% }%>
        </div>
        <%--AlertEND--%>
        <div class="container text-center  card  position-absolute top-50 start-50 translate-middle p-5  m-5" style="width: 30rem;">
            <i class="fas fa-calendar-alt fs-1"  ></i>

            <div class="row p-2">

                <asp:Label ID="Label1" runat="server" Text="Inserte el año">                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Por favor, dígite el año" 
                    ControlToValidate="txtAnio" ValidationGroup="1" Font-Italic="True" ForeColor="Red" >*</asp:RequiredFieldValidator></asp:Label>                
                <asp:TextBox ID="txtAnio" runat="server" TextMode="Number" Text="2021"></asp:TextBox>
            </div>
            <div class="row p-2">
                <label class="form-label">Seleccione una sección si desea ver su horario</label>
                <br />
                <asp:DropDownList ID="txtSecciones" runat="server" class="dropdown-menu-secondary form-control" Width="100%" Height="40px">
                     <asp:ListItem Value="0" Text="--- Seleccione una opcion ---"></asp:ListItem>
                    <asp:ListItem class="dropdown-item">7-1</asp:ListItem>
                    <asp:ListItem class="dropdown-item">7-2</asp:ListItem>
                    <asp:ListItem class="dropdown-item">7-3</asp:ListItem>
                    <asp:ListItem class="dropdown-item">7-4</asp:ListItem>
                    <asp:ListItem class="dropdown-item">8-1</asp:ListItem>
                    <asp:ListItem class="dropdown-item">8-2</asp:ListItem>
                    <asp:ListItem class="dropdown-item">8-3</asp:ListItem>
                    <asp:ListItem class="dropdown-item">9-1</asp:ListItem>
                    <asp:ListItem class="dropdown-item">9-2</asp:ListItem>
                    <asp:ListItem class="dropdown-item">10-1</asp:ListItem>
                    <asp:ListItem class="dropdown-item">10-2</asp:ListItem>
                    <asp:ListItem class="dropdown-item">11-1</asp:ListItem>
                    <asp:ListItem class="dropdown-item">12-1</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="row ">
                <asp:Button ID="btnCrear" CssClass="btn btn-outline-secondary  m-1" runat="server" Text="Crear horario" ValidationGroup="1" ToolTip="Los horarios se crearan automaticamente para todas las secciones" OnClick="btnCrear_Click" />
                <asp:Button ID="btnVer" runat="server" Text="Ver horario " class="btn btn-outline-secondary  m-1" ValidationGroup="1" OnClick="btnVer_Click" />

                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar horario" CssClass="btn btn-outline-secondary  m-1" ValidationGroup="1" OnClick="btnEliminar_Click" />
            </div>
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />


        </div>
        


    </div>


    


</asp:Content>
