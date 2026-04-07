package net.kbw.wook;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import org.springframework.data.web.PageableDefault;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;

import net.kbw.domain.Question;
import net.kbw.domain.QuestionRepository;
import net.kbw.domain.Serch;

@Controller
public class HomeController {
    @Autowired
    private QuestionRepository questionRepository;

    @GetMapping("")
    public String home(
        Model model,
        @PageableDefault(sort = "id", direction = Sort.Direction.DESC, size = 5) Pageable pageable,
        @RequestParam(required = false) Integer page,
        @RequestParam(required = false, defaultValue = "") String keyword
    ) {
        if (page == null) {
            // 페이지 파라미터 없으면 1페이지로 리다이렉트
            return "redirect:/?keyword=" + keyword + "&page=1";
        }

        Serch serch = new Serch();

        if (serch.Serch(keyword)) {
            Page<Question> question = questionRepository.findByTitleContaining(keyword, pageable);
            model.addAttribute("previous", pageable.previousOrFirst().getPageNumber());
            model.addAttribute("next", pageable.next().getPageNumber());
            model.addAttribute("hasNext", question.hasNext());
            model.addAttribute("hasPrev", question.hasPrevious());
            model.addAttribute("keyword", keyword);
            model.addAttribute("question", question);

            if (question.getTotalPages() == 0) {
                // 검색 결과가 없으면 그냥 뷰 보여주기
                return "/user/index";
            }
            return "/user/index";
        } else {
            Page<Question> question = questionRepository.findAll(pageable);
            model.addAttribute("question", question);
            model.addAttribute("previous", pageable.previousOrFirst().getPageNumber());
            model.addAttribute("next", pageable.next().getPageNumber());
            model.addAttribute("hasNext", question.hasNext());
            model.addAttribute("hasPrev", question.hasPrevious());
            model.addAttribute("keyword", keyword);

            return "/user/index";
        }
    }
}