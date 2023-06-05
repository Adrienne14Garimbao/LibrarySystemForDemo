/*  For Author > Index   */
(function ($) {

    var _authorAppService = abp.services.app.author,
        l = abp.localization.getSource('LibrarySystemForDemo'),
        _$form = $('form[name=authorSearchForm]');

    /*  Search  */
    _$form.find('.btn-search').on('click', (e) => {
        window.location.href = "/Author/Index";

    });

    $(document).on('click', '.edit-author', function () {
        var authorId = $(this).attr("data-author-id");
        window.location.href = "/Author/CreateOrEdit/" + authorId;

    });

    $(document).on('click', '.delete-author', function () {
        var authorId = $(this).attr("data-author-id");
        var authorName = $(this).attr("data-author-name");

        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'), authorName), '',

            function (isConfirmed) {
                if (isConfirmed) {
                    _authorAppService.delete({ id: authorId }).done(function () {
                        window.location.href = "/Author"
                        abp.notify.info(l('SuccessfullyDeleted'), 'Message');
                    })
                }
            }


        );


    });



})(jQuery);