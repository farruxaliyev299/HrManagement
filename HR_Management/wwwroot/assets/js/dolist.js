//List item text decoration
let checkBoxes = document.querySelectorAll('.form-check-input');
checkBoxes.forEach(box => {
    box.addEventListener('click', function(){
        let next = this.nextElementSibling.firstElementChild;
        if(this.checked){
            next.classList.add('checked');
        }
        else{
            next.classList.remove('checked');
        }
    })
})