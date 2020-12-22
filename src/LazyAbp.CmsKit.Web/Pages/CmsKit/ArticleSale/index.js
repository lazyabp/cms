$(function () {

    var l = abp.localization.getResource('CmsKit');

    var service = lazyAbp.cmsKit.articleSale;
    var createModal = new abp.ModalManager(abp.appPath + 'CmsKit/ArticleSale/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'CmsKit/ArticleSale/EditModal');

    var dataTable = $('#ArticleSaleTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('CmsKit.ArticleSale.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('CmsKit.ArticleSale.Delete'),
                                confirmMessage: function (data) {
                                    return l('ArticleSaleDeletionConfirmationMessage', data.record.id);
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
            { data: "userId" },
            { data: "articleId" },
            { data: "salePrice" },
            { data: "articleTitle" },
            { data: "status" },
            { data: "article" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewArticleSaleButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});