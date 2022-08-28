var swiper = new Swiper(".bg-slider-thumbs", {
    loop: true,
    spaceBetween: 0,
    slidesPerView: 0,
  });
  var swiper2 = new Swiper(".bg-slider", {
    loop: true,
    spaceBetween: 0,
    thumbs: {
      swiper: swiper,
    },
  });


  window.addEventListener("scroll",function(){
    const header =document.querySelector("header");
    header.classList.toggle("sticky",window.scrollY>0)

  });


  const menuBtn=document.querySelector(".nav-menu-btn");
  const closeBtn=document.querySelector(".nav-close-btn");
  const navigation=document.querySelector(".navigation");

  menuBtn.addEventListener("click",()=>{
    navigation.classList.add("active");
  });

  closeBtn.addEventListener("click",()=>{
    navigation.classList.remove("active");
  });

  flatpickr("input[type=datetime-local]", {});

  var swiper = new Swiper(".mySwiper", {
    slidesPerView: 3,
    spaceBetween: 30,
    pagination: {
      el: ".swiper-pagination",
      clickable: true,
    },

    breakpoints:{
      0:{
        slidesPerView:1,
      },
      768:{
        slidesPerView:2,
      },
      992:{
        slidesPerView:3,
      }
    }
  });

  $(document).ready(function(){
    $('.list').click(function(){
      const value =$(this).attr('data-filter');
      if (value == 'main') {
        $('.filter').show('800');
      }
      else{
        $('.filter').not('.'+value).hide('800')
        $('.filter').filter('.'+value).show('800')
      }
    });

    $('.list').click(function(){
      $(this).addClass('active').siblings().removeClass('active');
    })
  });

  AOS.init();

  let tabs=document.querySelectorAll('.tabs-toggle'),
  contents=document.querySelectorAll('.services');

  tabs.forEach((tab,index)=>{
    tab.addEventListener('click',()=>{
      contents.forEach((content)=>{
        content.classList.remove('is-active');
      });
      tabs.forEach((tab)=>{
        tab.classList.remove('is-active');
      });
      contents[index].classList.add('is-active');
      tabs[index].classList.add('is-active');
    });
  });