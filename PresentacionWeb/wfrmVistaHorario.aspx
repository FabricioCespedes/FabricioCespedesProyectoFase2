<%@ Page Title="" Language="C#" MasterPageFile="~/wfrmPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmVistaHorario.aspx.cs" Inherits="PresentacionWeb.wfrmVistaHorario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card text-center">
            <h1 class="card-title">Horario seccion   <% = Session["_Seccion"]%> </h1>
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
                <% = Session["_err"]%>
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>

            <% }%>

            <%if (Session["_wrn"] != null)
                {%>
            <div class="alert alert-warning" role="alert">
                <% = Session["_wrn"]%>
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>
            <% }%>
        </div>
        <%--AlertEND--%>
        <div class="row p-2">

            <asp:Button class="btn btn-outline-secondary  m-1" ID="Button1" runat="server" Text="Regresar" OnClick="Button1_Click"  />
        </div>
        <div class="row ">
            <div class="row p-2">
                <asp:Label ID="lblSecciones" runat="server" Text="Seleccione el grupo y precione cambiar" Visible="False"></asp:Label>
                <br />
                <asp:DropDownList ID="txtSecciones" runat="server" class="dropdown-menu-secondary form-control" Width="100%" Height="40px" Visible="False">
                    <asp:ListItem class="dropdown-item">A</asp:ListItem>
                    <asp:ListItem class="dropdown-item">B</asp:ListItem>
                </asp:DropDownList>
                <asp:Button class="btn btn-outline-secondary  m-1" ID="btnCambiar" runat="server" Text="Cambiar de grupo" OnClick="btnCambiar_Click" Visible="False" />
            </div>
            <div class="row ">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Bold="False" EmptyDataText="Leccion libre" HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField DataField="Lecciones" HeaderText="Lecciones">
                            <ControlStyle Width="100px" />
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                            <ItemStyle ForeColor="#FF3300" HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Lunes" HeaderText="Lunes">
                            <HeaderStyle HorizontalAlign="Center" Width="250px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Martes" HeaderText="Martes">
                            <ItemStyle HorizontalAlign="Center" Width="250px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Miercoles" HeaderText="Miercoles">
                            <ItemStyle HorizontalAlign="Center" Width="250px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Jueves" HeaderText="Jueves">
                            <ItemStyle HorizontalAlign="Center" Width="250px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Viernes" HeaderText="Viernes">
                            <ItemStyle HorizontalAlign="Center" Width="250px" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle Width="50px" Height="100px" HorizontalAlign="Center" BackColor="#666699" ForeColor="White" Font-Size="Medium" Font-Bold="True" />
                    <PagerStyle HorizontalAlign="Center" />
                    <RowStyle Height="50px" />
                    <SortedAscendingCellStyle Width="30px" />
                </asp:GridView>

            </div>



        </div>
</asp:Content>
