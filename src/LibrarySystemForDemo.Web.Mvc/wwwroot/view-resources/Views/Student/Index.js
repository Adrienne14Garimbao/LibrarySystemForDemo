/*  For Students > Index   */
(function ($) {

    var _studentAppService = abp.services.app.student,
        l = abp.localization.getSource('LibrarySystemForDemo'),
        _$form = $('form[name=studentSearchForm]');

    /* Search */
    _$form.find('.btn-search').on('click', (e) => {
        window.location.href = "/Student/Index";
    });

    $(document).on('click', '.edit-student', function () {
        var studentId = $(this).attr("data-student-id");
        window.location.href = "/Student/CreateOrEdit/" + studentId;

    });

    $(document).on('click', '.delete-student', function () {
        var studentId = $(this).attr("data-student-id");
        var studentName = $(this).attr("data-student-name");

        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'), studentName), '',

            function (isConfirmed) {
                if (isConfirmed) {
                    _studentAppService.delete({ id: studentId }).done(function () {
                        window.location.href = "/Student"
                    })
                }
            }


        );


    });


})(jQuery);