/*  For Student > CreateOrEdit   */
(function ($) {

    var _studentAppService = abp.services.app.student,
        l = abp.localization.getSource('LibrarySystemForDemo'),
        _$form = $('form[name=StudentForm]');

    _$form.find('.save-button').on('click', (e) => {
        save();
    })

    _$form.find('.cancel-button').on('click', (e) => {
        cancelAndReturn();
    })

    function save() {

        if (!_$form.valid()) {
            return;
        }

        var student = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);

        if (student.Id != 0) //Not Empty > Then > Update or Edit
        {
            _studentAppService.update(student).done(function () {
                redirectToStudentIndex();
                abp.message.success('Successfully Updated!', 'Updated');
            });
        }
        else //Student Id has Value > Then > Create 
        {
            _studentAppService.create(student).done(function () {
                redirectToStudentIndex();
                abp.message.success('Successfully Saved!', 'Saved');
            });
        }

    }

    function redirectToStudentIndex() {
        abp.notify.info(l('Success'), 'Message');
        window.location.href = "/Student";
    }

    function cancelAndReturn() {
        abp.message.confirm('Are you sure you want to cancel?', 'Go Back')
            .then(function (confirmed) {
                if (confirmed) {
                    window.location.href = "/Student";
                }
            });
    }


})(jQuery);
