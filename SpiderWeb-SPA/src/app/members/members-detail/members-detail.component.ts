import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';

@Component({
  selector: 'app-members-detail',
  templateUrl: './members-detail.component.html',
  styleUrls: ['./members-detail.component.css']
})
export class MembersDetailComponent implements OnInit {
user: User;
galleryOptions: NgxGalleryOptions[];
galleryImages: NgxGalleryImage[];


 constructor(private userService: UserService, private alertify: AlertifyService,
   private route: ActivatedRoute ) { }

  ngOnInit() {
    this.route.data.subscribe(data =>{
      this.user = data['user']
    });


    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns:4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview:false
      }
    ];

    this.galleryImages = this.getImages();
  }

  getImages(){
    const imageurls = [];
    for(let i = 0; i < this.user.photos.length; i++)
    {
      imageurls.push({
        small: this.user.photos[i].url,
        medium: this.user.photos[i].url,
        big: this.user.photos[i].url,
        description: this.user.photos[i].description
      });
    }
    return imageurls;
  }

  Join(){
    this.alertify.message("Registerd in New event");
  }



}
