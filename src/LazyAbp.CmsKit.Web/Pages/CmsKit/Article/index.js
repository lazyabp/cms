$(function () {

    var l = abp.localization.getResource('CmsKit');

    var service = lazyAbp.cmsKit.article;
    var createModal = new abp.ModalManager(abp.appPath + 'CmsKit/Article/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'CmsKit/Article/EditModal');

    var dataTable = $('#ArticleTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('CmsKit.Article.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('CmsKit.Article.Delete'),
                                confirmMessage: function (data) {
                                    return l('ArticleDeletionConfirmationMessage', data.record.id);
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
            { data: "origin" },
            { data: "auth" },
            { data: "thumbnail" },
            { data: "descritpion" },
            { data: "file" },
            { data: "video" },
            { data: "price" },
            { data: "hits" },
            { data: "likes" },
            { data: "dislikes" },
            { data: "favorites" },
            { data: "comments" },
            { data: "sales" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewArticleButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});