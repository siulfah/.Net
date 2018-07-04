<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrudCountry.aspx.cs" Inherits="FormExam.CrudCountry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 235px;
            height: 302px;
        }
        .auto-style5 {
            width: 551px;
            height: 302px;
        }
        .auto-style7 {
            width: 100%;
        }
        .auto-style12 {
            height: 34px;
            width: 551px;
        }
        .auto-style13 {
            height: 34px;
        }
        .auto-style14 {
            width: 235px;
            height: 34px;
        }
        .auto-style15 {
            width: 168px;
        }
        .auto-style16 {
            width: 36px;
        }
        .auto-style20 {
            width: 168px;
            height: 26px;
        }
        .auto-style21 {
            width: 36px;
            height: 26px;
        }
        .auto-style22 {
            height: 26px;
        }
        .auto-style23 {
            width: 168px;
            height: 23px;
        }
        .auto-style24 {
            width: 36px;
            height: 23px;
        }
        .auto-style25 {
            height: 23px;
        }
        .auto-style26 {
            margin-left: 40px;
        }
        .auto-style27 {
            margin-left: 40px;
            height: 23px;
        }
        .auto-style29 {
            width: 168px;
            height: 33px;
        }
        .auto-style30 {
            width: 36px;
            height: 33px;
        }
        .auto-style31 {
            margin-left: 40px;
            height: 33px;
        }
        .auto-style32 {
            height: 302px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style7">
                <tr>
                    <td class="auto-style1" colspan="3"><strong>CRUD DATA COUNTRY</strong></td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style5">
                        <table class="auto-style7">
                            <tr>
                                <td class="auto-style20">
                                    <asp:Label ID="Label2" runat="server" Text="Country Name"></asp:Label>
                                </td>
                                <td class="auto-style21">:</td>
                                <td class="auto-style22">
                                    <asp:TextBox ID="countryNameInput" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style23">
                                    <asp:Label ID="Label3" runat="server" Text="Continent"></asp:Label>
                                </td>
                                <td class="auto-style24">:</td>
                                <td class="auto-style25">
                                    <asp:TextBox ID="ContinentInput" runat="server"></asp:TextBox>
                                </td>
                            </tr>                            
                            <tr>
                                <td class="auto-style15">
                                    <asp:Label ID="Label4" runat="server" Text="Region"></asp:Label>
                                </td>
                                <td class="auto-style16">:</td>
                                <td>
                                    <asp:DropDownList ID="regionDropdown" runat="server" DataSourceID="regional" DataTextField="Region" DataValueField="Region_id" OnSelectedIndexChanged="regionDropdown_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="regional" runat="server" ConnectionString="<%$ ConnectionStrings:worldConnectionString %>" SelectCommand="SELECT * FROM [Region]"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style15">
                                    <asp:Label ID="SurfaceArea" runat="server" Text="SurfaceArea"></asp:Label>
                                </td>
                                <td class="auto-style16">:</td>
                                <td class="auto-style26">
                                    <asp:TextBox ID="surfaceAreaInput" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style15">
                                    <asp:Label ID="Label5" runat="server" Text="IndependentYear"></asp:Label>
                                </td>
                                <td class="auto-style16">:</td>
                                <td class="auto-style26">
                                    <asp:TextBox ID="inYeInput" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style15">
                                    <asp:Label ID="Label6" runat="server" Text="Population"></asp:Label>
                                </td>
                                <td class="auto-style16">:</td>
                                <td class="auto-style26">
                                    <asp:TextBox ID="populationInput" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style23"></td>
                                <td class="auto-style24"></td>
                                <td class="auto-style27"></td>
                            </tr>
                            <tr>
                                <td class="auto-style15">&nbsp;</td>
                                <td class="auto-style16">&nbsp;</td>
                                <td class="auto-style26">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style29"></td>
                                <td class="auto-style30"></td>
                                <td class="auto-style31">
                                    <asp:Button ID="buttonSave" OnClick="Button1_Click" runat="server" Text="Save" /> 
                                    
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style23"></td>
                                <td class="auto-style24"></td>
                                <td class="auto-style27"></td>
                            </tr>
                        </table>
                    </td>
                    <td class="auto-style32"></td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style12">
                        &nbsp;</td>
                    <td class="auto-style13">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14"></td>
                    <td class="auto-style12">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Country_id" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Country_id" HeaderText="Country_id" InsertVisible="False" ReadOnly="True" SortExpression="Country_id" />
                                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                                <asp:BoundField DataField="Continent" HeaderText="Continent" SortExpression="Continent" />
                                <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                                <asp:BoundField DataField="Surface_Area" HeaderText="Surface_Area" SortExpression="Surface_Area" />
                                <asp:BoundField DataField="Indep_Year" HeaderText="Indep_Year" SortExpression="Indep_Year" />
                                <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" ShowSelectButton="True" SelectText="" />
                                <asp:CommandField HeaderText="Update"  SelectText="Update" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:worldConnectionString %>" DeleteCommand="DELETE FROM Country WHERE (Country_id = @Country_id)" SelectCommand="SELECT Country.Country_id, Country.Country, Country.Continent, Region.Region, Country.Surface_Area, Country.Indep_Year, Country.Population FROM Country INNER JOIN Region ON Country.Region_id = Region.Region_id"></asp:SqlDataSource>
                    </td>
                    <td class="auto-style13">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
