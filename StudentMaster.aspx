<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="StudentMaster.aspx.cs" Inherits="StudentManagementSystemWithLayers.StudentMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="XX-Large" ForeColor="#993300" Text="Student Record"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 80px">Student Name:</td>
            <td style="width: 216px">
                <asp:TextBox ID="txtStdName" runat="server" Width="248px"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td style="text-align: right; width: 80px">Father&#39;s Name:</td>
            <td style="width: 216px">
                <asp:TextBox ID="txtFather" runat="server" Width="245px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 80px">Address:</td>
            <td style="width: 216px">
                <asp:TextBox ID="txtAddress" runat="server" Width="246px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 80px">Mobile:</td>
            <td style="width: 216px">
                <asp:TextBox ID="txtMobile" runat="server" Width="246px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 80px">Gender:</td>
            <td style="width: 216px">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 80px">Course:</td>
            <td style="width: 216px">
                <asp:dropdownlist runat="server" ID="ddCourse" AutoPostBack="true" AppendDataBoundItems="true">
                    <asp:ListItem Value="0">--Select Course--</asp:ListItem>
                </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 80px">Teacher Name:</td>
            <td style="width: 216px">
                <asp:dropdownlist runat="server" ID="ddTeacher" AutoPostBack="true" AppendDataBoundItems="true">
                    <asp:ListItem Value="0">--Select Teacher--</asp:ListItem>
                </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 80px">Email:</td>
            <td style="width: 216px">
                <asp:TextBox ID="txtEmail" runat="server" Width="242px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="92px" />
                &nbsp;&nbsp;
                <asp:Button ID="BtnDelete" runat="server" OnClick="btnDelete_Click" Text="Reset" Width="92px" />
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 80px">&nbsp;</td>
            <td style="width: 216px">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtId" runat="server" type="hidden"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand" DataKeyNames="Id">
                    <Columns>
                    <asp:TemplateField HeaderText="S.No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            StudentName
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="butType" runat="server" CommandName="updates" Text='<%# Eval("StdName") %>' CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:BoundField DataField="FatherName" HeaderText="Father Name" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                        <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                        <asp:BoundField DataField="TeacherName" HeaderText="Teacher Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="butEnable" runat="server" class="btn btn-warning btn-xs" CommandName="enable" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                   
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
                </td>
        </tr>
    </table>
</asp:Content>
