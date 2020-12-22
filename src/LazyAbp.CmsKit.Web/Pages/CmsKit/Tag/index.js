$(function () {

    var l = abp.localization.getResource('CmsKit');

    var service = lazyAbp.cmsKit.tag;
    var createModal = new abp.ModalManager(abp.appPath + 'CmsKit/Tag/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'CmsKit/Tag/EditModal');

    var dataTable = $('#TagTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('CmsKit.Tag.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('CmsKit.Tag.Delete'),
                                confirmMessage: function (data) {
                                    return l('TagDeletionConfirmationMessage', data.record.id);
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
            { data: "hits" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewTagButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});