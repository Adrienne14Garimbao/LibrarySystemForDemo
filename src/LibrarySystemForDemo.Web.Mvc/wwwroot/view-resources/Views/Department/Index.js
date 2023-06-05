/*  For Departments > Index   */
(function ($) {

    var _departmentService = abp.services.app.department,
        l = abp.localization.getSource('LibrarySystemForDemo'),
        _$form = $('form[name=departmentSearchForm]');

    /* Search */
    _$form.find('.btn-search').on('click', (e) => {
        window.location.href = "/Department/Index";
    });


    $(document).on('click', '.edit-department', function () {
        var departmentId = $(this).attr("data-department-id");
        window.location.href = "/Department/CreateOrEdit/" + departmentId;

    });


    $(document).on('click', '.delete-department', function () {
        var departmentId = $(this).attr("data-department-id");
        var departmentName = $(this).attr("data-department-name");

        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'), departmentName), '',

            function (isConfirmed) {
                if (isConfirmed) {
                    _departmentService.delete({ id: departmentId }).done(function () {
                        window.location.href = "/Department"
                    })
                }
            }


        );


    });




})(jQuery);