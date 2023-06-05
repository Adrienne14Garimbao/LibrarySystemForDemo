/*  For Category > Index   */

(function ($) {

    var _categoryAppService = abp.services.app.category,
        l = abp.localization.getSource('LibrarySystemForDemo'),
        _$form = $('form[name=categorySearchForm]');

    /* Search */
    _$form.find('.btn-search').on('click', (e) => {
        window.location.href = "/Category/Index";
    });

    $(document).on('click', '.edit-category', function () {
        var categoryId = $(this).attr("data-category-id");
        window.location.href = "/Category/CreateOrEdit/" + categoryId;

    });

    $(document).on('click', '.delete-category', function () {
        var categoryId = $(this).attr("data-category-id");
        var categoryName = $(this).attr("data-category-name");

        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'), categoryName), '',

            function (isConfirmed) {
                if (isConfirmed) {
                    _categoryAppService.delete({ id: categoryId }).done(function () {
                        window.location.href = "/Category"
                    })
                }
            }


        );


    });



})(jQuery);