$(function () {

    var l = abp.localization.getResource('Cms');

    var service = lazyAbp.cmsKit.singlePage;
    var createModal = new abp.ModalManager(abp.appPath + 'Cms/SinglePage/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Cms/SinglePage/EditModal');

    var dataTable = $('#SinglePageTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Cms.SinglePage.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Cms.SinglePage.Delete'),
                                confirmMessage: function (data) {
                                    return l('SinglePageDeletionConfirmationMessage', data.record.id);
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
            { data: "title" },
            { data: "thumbnail" },
            { data: "fullDescription" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewSinglePageButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});