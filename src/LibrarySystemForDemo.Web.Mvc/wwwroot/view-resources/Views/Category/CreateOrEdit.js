/*  For Category > Create or Edit   */
(function ($) {

    var _categoryAppService = abp.services.app.category,
        l = abp.localization.getSource('LibrarySystemForDemo'),
        _$form = $('form[name=CategoryForm]');

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

        var category = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);

        if (category.Id != 0) //Not Empty > Then > Update or Edit
        {
            _categoryAppService.update(category).done(function () {
                redirectToCategoryIndex();
                abp.message.success('Successfully Updated!', 'Updated');
            });
        }
        else //Category Id has Value > Then > Create 
        {
            _categoryAppService.create(category).done(function () {
                redirectToCategoryIndex();
                abp.message.success('Successfully Saved!', 'Saved');

            });
        }

    }

    function redirectToCategoryIndex() {
        abp.notify.info(l('Success'), 'Message');
        window.location.href = "/Category";
    }

    function cancelAndReturn() {
        abp.message.confirm('Are you sure you want to cancel?', 'Go Back')
            .then(function (confirmed) {
                if (confirmed) {
                    window.location.href = "/Category";
                }
            });
    }


})(jQuery);