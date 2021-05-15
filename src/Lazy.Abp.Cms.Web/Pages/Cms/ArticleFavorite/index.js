$(function () {

    var l = abp.localization.getResource('Cms');

    var service = lazyAbp.cmsKit.articleFavorite;
    var createModal = new abp.ModalManager(abp.appPath + 'Cms/ArticleFavorite/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Cms/ArticleFavorite/EditModal');

    var dataTable = $('#ArticleFavoriteTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Cms.ArticleFavorite.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Cms.ArticleFavorite.Delete'),
                                confirmMessage: function (data) {
                                    return l('ArticleFavoriteDeletionConfirmationMessage', data.record.id);
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
            { data: "article" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewArticleFavoriteButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});