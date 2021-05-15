$(function () {

    var l = abp.localization.getResource('Cms');

    var service = lazyAbp.cmsKit.userCategory;
    var createModal = new abp.ModalManager(abp.appPath + 'Cms/UserCategory/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Cms/UserCategory/EditModal');

    var dataTable = $('#UserCategoryTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('Cms.UserCategory.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Cms.UserCategory.Delete'),
                                confirmMessage: function (data) {
                                    return l('UserCategoryDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                        service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            { data: "name" },
            { data: "level" },
            { data: "parentId" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewUserCategoryButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});