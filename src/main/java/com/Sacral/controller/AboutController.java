package com.Sacral.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.Sacral.service.AboutService;

@RestController
public class AboutController {
   
    @Autowired
    AboutService aboutService;

    @GetMapping("/introduction")
    public String getIntroduction() {
        return aboutService.getIntroduction();
    }

    @GetMapping("/goals")
    public String getGoals() {
        return aboutService.getGoals();
    }

    @GetMapping("/sendEmail")
    public void sendEmail(@RequestParam String email) {
        aboutService.sendEmail(email);
    }
}