<%@ Page Title="" Language="C#" MasterPageFile="~/wfrmPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmAsistencia.aspx.cs" Inherits="PresentacionWeb.wfrmAsistencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="card text-center">
            <h1 class="card-title">Control de asistencia</h1>
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
        <div class="col justify-content-start">
            <div class="row align-items-start">
                <div class="container text-center  card  position-absolute  p-5  m-5" style="width: 30rem; top: 30%; left: 10%;">
                    <i class="fas fa-clipboard-list fs-1"></i>
                    <div class="row p-2">
                        <form>
                            <div class="mb-3">
                                <asp:Label ID="Label1" runat="server" Text="Inserte la fecha"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" class="form-control" Width="100%" Height="40px" OnTextChanged="txtFecha_TextChanged" AutoPostBack="True"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Seleccione una sección</label>
                                <br />
                                <asp:DropDownList ID="txtSecciones" runat="server" class="dropdown-menu-secondary form-control" Width="100%" Height="40px" OnSelectedIndexChanged="txtSecciones_SelectedIndexChanged" AutoPostBack="True" Enabled="False">
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
                            <div class="mb-3">
                                <asp:Label ID="Label2" runat="server" Text="Inserte la materia"></asp:Label>
                                <asp:DropDownList AppendDataBoundItems="true" ID="ddlMaterias" runat="server" class="dropdown-menu-secondary form-control" Width="100%" Height="40px" Enabled="False" OnSelectedIndexChanged="ddlMaterias_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Value="0" Text="--- Seleccione una opcion ---"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="Label3" runat="server" Text="Inserte la leccion"></asp:Label>
                                <asp:DropDownList AppendDataBoundItems="true" ID="ddlLecciones" runat="server" class="dropdown-menu-secondary form-control " Width="100%" Height="40px" Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="ddlLecciones_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="--- Seleccione una opcion ---"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <asp:Button ID="btnVer" runat="server" Text="Ver el registro seleccionado" CssClass="btn btn-outline-secondary  m-1" Enabled="False" OnClick="btnVer_Click" />
                            <asp:Button ID="bntGuardar" runat="server" Text="Guardar" CssClass="btn btn-outline-secondary  m-1" OnClick="bntGuardar_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class="row align-items-start">
            <div class="col align-self-end">
                <asp:GridView CssClass="table table-borderedtable-striped table-hover card  position-absolute p-5  m-5" Style="width: 700px; top: 30%; left: 45%;" ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="Identificacion" ItemStyle-HorizontalAlign="Center" ItemStyle-Height="50px" ItemStyle-Width="100px">
                            <ItemStyle HorizontalAlign="Center" Height="50px" Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-Height="50px" ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Justify" HeaderStyle-Width="200px" HeaderStyle-Height="50px">
                            <HeaderStyle Height="50px" Width="200px"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Justify" Height="50px" Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Estado" ItemStyle-Width="200px">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlEstado" runat="server" class="dropdown-menu-secondary form-control">
                                    <asp:ListItem class="dropdown-item" Value="0" Text="Seleccione una opcion"></asp:ListItem>
                                    <asp:ListItem class="dropdown-item">Presente</asp:ListItem>
                                    <asp:ListItem class="dropdown-item">Ausente</asp:ListItem>
                                    <asp:ListItem class="dropdown-item">Tardia</asp:ListItem>
                                    <asp:ListItem class="dropdown-item">Permiso salida</asp:ListItem>
                                    <asp:ListItem class="dropdown-item">Salida emergencia</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>

                            <ItemStyle Width="200px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CommandArgument='<%# Eval("id").ToString() %>' OnCommand="LinkButton1_Command">Eliminar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="id" HeaderText="id" HtmlEncode="False" HtmlEncodeFormatString="False" Visible="False" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
