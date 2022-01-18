<%@ Page Title="" Language="C#" MasterPageFile="~/wfrmPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmCalificaciones.aspx.cs" Inherits="PresentacionWeb.wfrmCalificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <div class="card text-center">
            <h1 class="card-title">Calificaciones</h1>
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
                <div class="container text-center  card  position-absolute  p-1  m-1" style="width: 30rem; top: 20%; left: 8%;">
                    <i class="fas fa-clipboard-list fs-1"></i>
                    <div class="row p-2">
                        <form>
                            <div class="mb-3">
                                <asp:Label ID="Label1" runat="server" Text="Inserte el año"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtAnio" runat="server" TextMode="Number" class="form-control" Width="100%" Height="40px" AutoPostBack="True" OnTextChanged="txtAnio_TextChanged"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Seleccione una sección</label>
                                <br />
                                <asp:DropDownList ID="txtSecciones" runat="server" class="dropdown-menu-secondary form-control" Width="100%" Height="40px" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="txtSecciones_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="Label2" runat="server" Text="Materia"></asp:Label>
                                <asp:TextBox ID="txtMateria" runat="server" class="form-control" Width="100%" Height="40px" AutoPostBack="True" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="Label3" runat="server" Text="Docente"></asp:Label>
                                <asp:TextBox ID="txtProfe" runat="server" class="form-control" Width="100%" Height="40px" AutoPostBack="True" Enabled="false"></asp:TextBox>
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
                <asp:GridView CssClass="table table-borderedtable-striped table-hover card  position-absolute p-1  m-1" Style="width: 820px; top: 20%; left: 41%; margin-right: 0px;" ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="Identificacion" ItemStyle-HorizontalAlign="Center" ItemStyle-Height="50px" ItemStyle-Width="100px">
                            <ItemStyle HorizontalAlign="Center" Height="50px" Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-Height="50px" ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Justify" HeaderStyle-Width="200px" HeaderStyle-Height="50px">
                            <HeaderStyle Height="50px" Width="200px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Justify" Height="50px" Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="I">
                            <ItemTemplate>
                                <asp:TextBox ID="txtPrimerTrimestre" runat="server" Width="35px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Borrar" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("id").ToString() %>' OnCommand="LinkButton1_Command" ForeColor="#666699"><i class="fas fa-trash-alt"></i></asp:LinkButton>
                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Solicitar cambio" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSolicitarI" runat="server" OnCommand="LinkButton2_Command" CommandArgument='<%# Eval("id").ToString() %>' ForeColor="#666699"><i class="fas fa-exchange-alt"></i></asp:LinkButton>
                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="II">
                            <ItemTemplate>
                                <asp:TextBox ID="txtSegundoTrimestre" runat="server" Width="35px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Borrar" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("id").ToString() %>' OnCommand="LinkButton3_Command" ForeColor="#666699"><i class="fas fa-trash-alt"></i></asp:LinkButton>
                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Solicitar cambio" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSolicitarII" runat="server" CommandArgument='<%# Eval("id").ToString() %>' OnCommand="lnkSolicitarII_Command" ForeColor="#666699"><i class="fas fa-exchange-alt"></i></asp:LinkButton>
                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="III">
                            <ItemTemplate>
                                <asp:TextBox ID="txtTercerTrimestre" runat="server" Width="35px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Borrar" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='<%# Eval("id").ToString() %>' OnCommand="LinkButton4_Command" ForeColor="#666699"><i class="fas fa-trash-alt"></i></asp:LinkButton>
                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Solicitar cambio" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="#666699">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSolicitarIII" runat="server" CommandArgument='<%# Eval("id").ToString() %>' OnCommand="lnkSolicitarII_Command1" ForeColor="#666699"><i class="fas fa-exchange-alt"></i></asp:LinkButton>
                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center" ForeColor="#666699"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="id" HeaderText="id" HtmlEncode="False" HtmlEncodeFormatString="False" Visible="False" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
