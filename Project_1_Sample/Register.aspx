<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Project_1_Sample.Register" %>

<!DOCTYPE html>  
  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title></title>  
    <link rel="stylesheet" href="~/Content/bootstrap.min.css" />  
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>  
    <script src="~/Scripts/bootstrap.min.js"></script>  

</head>  
<body>  
    <form  id="form1" runat="server">  
        <div style="padding-left:25px; padding-top:25px">  
            <table class="auto-style1">  
                <tr>  
                    <td>Prouct Name </td>  
                    <td>  
                        <asp:TextBox ID="name" runat="server" required="true"></asp:TextBox>  
                    </td>  
  
               </tr>  
                <tr>  
                    <td>Discription</td>  
                     <td> <asp:TextBox ID="discription" runat="server" required="true" ></asp:TextBox></td>  
                </tr>  
                <tr>  
                    <td>Price</td>  
                    <td>  
                        <asp:TextBox ID="price" runat="server" required="true"></asp:TextBox>  
                    </td>  
                </tr>  
                <tr>  
                    <td>Qty</td> 
                    <td>  
                        <asp:TextBox ID="qty" runat="server" required="true"></asp:TextBox>  
                    </td>  
                </tr>    
                <tr>  
                    <td>Upload Image</td> 
                    <td> 
                        &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" required="true" />     
                        <asp:Label id="lblUploadResult" Runat="server"></asp:Label>
                    </td>  
                </tr> 

              

                <tr>  
                    <td>  
                        <asp:Button type="button" class="btn btn-primary" ID="Create" runat="server" Text="Submit" OnClick="Insert" Height="29px" />  
                    </td>  
                </tr>  
            </table>  
        </div>  



        <div style="margin-left: 280px">


            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CreateProductConnectionString %>" SelectCommand="SELECT * FROM [Product]"></asp:SqlDataSource>

        </div>

        <div style="margin-left: 280px">
            <asp:GridView class="table table-bordered table-condensed table-responsive table-hover " ID="GridView1" runat="server" Height="296px" Width="684px" AutoGenerateColumns="False" DataKeyNames="Id"  OnRowEditing="OnRowEditing"  OnRowUpdating="OnRowUpdating" OnRowCancelingEdit="OnRowCancelingEdit" AllowPaging ="true" OnPageIndexChanging = "OnPaging"  OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added."
                
                >
                
               <%-- /*DataSourceID="SqlDataSource1"*/--%>

                 <Columns>
                    <%--<asp:BoundField ItemStyle-Width="150px" DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />

                    <asp:BoundField ItemStyle-Width="150px" DataField="Pname" HeaderText="Pname" SortExpression="Pname" />

                    <asp:BoundField ItemStyle-Width="150px" DataField="PDiscription" HeaderText="PDiscription" SortExpression="PDiscription" />

                    <asp:BoundField ItemStyle-Width="150px" DataField="Price" HeaderText="Price" SortExpression="Price" />

                     <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty" />

                     <asp:TemplateField>
                         <ItemTemplate>

  <asp:Image ID ="Image1" runat="server" Height="100px" Width="100px" 
      ImageUrl='<%# Eval("prod_imgpath") %>'

      />
                         </ItemTemplate>
                     </asp:TemplateField>

                      <asp:BoundField HeaderText="Edit" SortExpression="Edit" />--%>


               
                <asp:TemplateField HeaderText="Pname" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblPname" runat="server" Text='<%# Eval("Pname") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="name" runat="server" Text='<%# Eval("Pname") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                     <asp:TemplateField HeaderText="PDiscription" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblPDiscription" runat="server" Text='<%# Eval("PDiscription") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="discription" runat="server" Text='<%# Eval("PDiscription") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                     <asp:TemplateField HeaderText="Price" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="price" runat="server" Text='<%# Eval("Price") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                     <asp:TemplateField HeaderText="Qty" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox ID="qty" runat="server" Text='<%# Eval("Qty") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>

                </asp:TemplateField>

                     <asp:TemplateField HeaderText="Image" ItemStyle-Width="150">
                    <ItemTemplate>
                        
                          <asp:Image ID ="Image1" runat="server" Height="100px" Width="100px" 
      ImageUrl='<%# Eval("prod_imgpath") %>' />


                    </ItemTemplate>

                   
                </asp:TemplateField>

                     
  <%--<asp:Image ID ="Image1" runat="server" Height="100px" Width="100px" 
      ImageUrl='<%# Eval("prod_imgpath") %>--%>




                      <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                    ItemStyle-Width="150" />



                </Columns>


            </asp:GridView>

        </div>

    </form>  
</body>  
</html> 
