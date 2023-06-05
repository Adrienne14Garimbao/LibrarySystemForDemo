/*  For Books > Index   */
(function ($) {

    var _booksAppService = abp.services.app.book,
        l = abp.localization.getSource('LibrarySystemForDemo'),
        _$form = $('form[name=bookSearchForm]');

    /*  Search  */
    _$form.find('.btn-search').on('click', (e) => {
        window.location.href = "/Book/Index";

    });


    $(document).on('click', '.edit-book', function () {
        var bookId = $(this).attr("data-book-id");
        window.location.href = "/Book/CreateOrEdit/" + bookId;

    });


    $(document).on('click', '.delete-book', function () {
        var bookId = $(this).attr("data-book-id");
        var bookName = $(this).attr("data-book-name");

        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'), bookName), '',

            function (isConfirmed) {
                if (isConfirmed) {
                    _booksAppService.delete({ id: bookId }).done(function () {
                        window.location.href = "/Book"
                        abp.notify.info(l('SuccessfullyDeleted'), 'Message');
                    })
                }
            }


        );


    });


})(jQuery);