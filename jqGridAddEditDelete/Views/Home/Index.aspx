<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Contact Manager</h2>

    <table id="list" class="scroll" cellpadding="0" cellspacing="0"></table>
    <div id="listPager" class="scroll" style="text-align:center;"></div>                                                            
    <div id="listPsetcols" class="scroll" style="text-align:center;"></div>  

    <script type="text/javascript">
        function isValidPhone(value, name) {
            console.log('isValidPhone');
            var errorMessage = name + ': Invalid Format';
            var success = value.length === 14;
            return [success, success ? '' : errorMessage];
        }  

        $(document).ready(function () {
            var updateDialog = {
                url: '<%= Url.Action("Update", "Contact") %>'
                , closeAfterAdd: true
                , closeAfterEdit: true
                , afterShowForm: function (formId) {
                    $("#PhoneNumber").mask("(999) 999-9999");
                    $("#DateOfBirth").datepicker();
                }
                , afterclickPgButtons: function (whichbutton, formid, rowid) {
                    $("#PhoneNumber").mask("(999) 999-9999");
                }
                , modal: true
                
                , onclickSubmit: function (params) {
                    var ajaxData = {};

                    var list = $("#list");
                    var selectedRow = list.getGridParam("selrow");
                    rowData = list.getRowData(selectedRow);
                    ajaxData = { ContactId: rowData.ContactId };

                    return ajaxData;
                }
                
                , width: "400"
            };
            $.jgrid.nav.addtext = "Add";
            $.jgrid.nav.edittext = "Edit";
            $.jgrid.nav.deltext = "Delete";
            $.jgrid.edit.addCaption = "Add Contact";
            $.jgrid.edit.editCaption = "Edit Contact";
            $.jgrid.del.caption = "Delete Contact";
            $.jgrid.del.msg = "Delete selected Contact?";
            $("#list").jqGrid({
                url: '<%= Url.Action("List", "Contact") %>',
                datatype: 'json',
                mtype: 'GET',
                colNames: ['ContactId', 'Name', 'Date of Birth', 'E-mail', 'Phone Number', 'Married'],
                colModel: [
                    { name: 'ContactId', index: 'ContactId', width: 40, align: 'left', /* key: true,*/ editable: true, editrules: { edithidden: false }, hidedlg: true, hidden: true },
                    { name: 'Name', index: 'Name', width: 300, align: 'left', editable: true, edittype: 'text', editrules: { required: true }, formoptions: { elmsuffix: ' *'} },
                    { name: 'DateOfBirth', index: 'DateOfBirth', width: 200, align: 'left', formatter: 'date', datefmt: 'm/d/Y', editable: true, edittype: 'text', editrules: { required: true, date: true }, formoptions: { elmsuffix: ' *'} },
                    { name: 'Email', index: 'Email', width: 200, align: 'left', formatter: 'mail', editable: true, edittype: 'text', editrules: { required: true, email: true }, formoptions: { elmsuffix: ' *'} },
                    { name: 'PhoneNumber', index: 'PhoneNumber', width: 200, align: 'left', editable: true, edittype: 'text', editrules: { required: true, custom: true, custom_func: isValidPhone }, formoptions: { elmsuffix: ' *'} },
                    { name: 'IsMarried', index: 'IsMarried', width: 200, align: 'left', editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, editrules: { required: true}}],
                pager: $('#listPager'),
                rowNum: 1000,
                rowList: [1000],
                sortname: 'ContactId',
                sortorder: "desc",
                viewrecords: true,
                imgpath: '/Content/Themes/Redmond/Images',
                caption: 'Contact List',
                autowidth: true,
                ondblClickRow: function (rowid, iRow, iCol, e) {
                    $("#list").editGridRow(rowid, prmGridDialog);
                }
            }).navGrid('#listPager',
                {
                    edit: true, add: true, del: true, search: false, refresh: true
                },
                updateDialog,
                updateDialog,
                updateDialog
            );
        });       
    </script>
</asp:Content>
